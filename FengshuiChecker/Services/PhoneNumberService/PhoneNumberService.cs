using FengshuiChecker.Models;
using FengshuiChecker.Repositories;
using FengshuiChecker.ViewModels.Configuration;
using Newtonsoft.Json;
using System.Reflection;

namespace FengshuiChecker.Services.PhoneNumberService
{
    public class PhoneNumberService : IPhoneNumberService
    {
        private readonly IUnitOfWork _uow;

        public PhoneNumberService(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public async Task<string[]> GetShengfuiPhoneNumbers()
        {
            try
            {
                // Parse fengshui condition configuration
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"fengshuiCondition.json");
                var fengshuiConfig  = JsonConvert.DeserializeObject<FengshuiConfiguration>(File.ReadAllText(path));   

                var phoneNumbers = await _uow.PhoneNumberRepository.GetAllPhoneNumbers();
                //var phoneNumbers = fetchMockData();

                if (phoneNumbers.Length == 0)
                {
                    return new string[0];
                }

                if (fengshuiConfig == null)
                {
                    return phoneNumbers.Select(phone => phone.Value).ToArray();
                }

                var result = new List<string>();

                foreach (var phoneNumber in phoneNumbers)
                {
                    if (IsValidLength(phoneNumber, fengshuiConfig.MaxLength) && IsValidNetworkProvider(phoneNumber)
                        && IsLastTwoNumberValid(phoneNumber, fengshuiConfig.ValidLastNumbers)
                        && IsValidSum(phoneNumber, fengshuiConfig.MinSumFirst5Numbers, fengshuiConfig.MaxSumFirst5Numbers,
                                fengshuiConfig.MinSumLast5Numbers, fengshuiConfig.MaxSumLast5Numbers))
                    {
                        result.Add(phoneNumber.Value);
                    }
                }

                return result.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private bool IsValidLength(PhoneNumber phoneNumber, int maxLength)
        {
            if (phoneNumber == null || String.IsNullOrWhiteSpace(phoneNumber.Value))
            {
                return false;
            }

            if (phoneNumber.Value.Length > maxLength)
            {
                return false;
            }

            return true;
        }

        private bool IsValidNetworkProvider(PhoneNumber phoneNumber)
        {
            if (phoneNumber == null || String.IsNullOrWhiteSpace(phoneNumber.Value))
            {
                return false;
            }

            if (phoneNumber.PhoneNumberPrefix?.IsFengshuiType == false)
            {
                return false;
            }

            return true;
        }

        private bool IsLastTwoNumberValid(PhoneNumber phoneNumber, string[] validNumbers)
        {
            if (phoneNumber == null || String.IsNullOrWhiteSpace(phoneNumber.Value))
            {
                return false;
            }

            if (validNumbers == null || validNumbers.Length == 0)
            {
                return true;
            }

            var lastTwoCharacters = phoneNumber.Value.Substring(phoneNumber.Value.Length - 2);

            if (validNumbers.Contains(lastTwoCharacters))
            {
                return true;
            }

            return false;
        }

        private bool IsValidSum(PhoneNumber phoneNumber, int minSumFirst5Numbers, int maxSumFirst5Numbers, int minSumLast5Numbers, int maxSumLast5Numbers)
        {
            if (phoneNumber == null || String.IsNullOrWhiteSpace(phoneNumber.Value))
            {
                return false;
            }

            var first5Characters = phoneNumber.Value.Substring(0, 5);
            var last5Characters = phoneNumber.Value.Substring(phoneNumber.Value.Length - 5);

            var sumFirst5Characters = SumOfPhoneNumber(first5Characters);
            var sumLast5Characters = SumOfPhoneNumber(last5Characters);

            if (sumFirst5Characters < minSumFirst5Numbers || sumFirst5Characters > maxSumFirst5Numbers
                || sumLast5Characters < minSumLast5Numbers || sumLast5Characters > maxSumLast5Numbers)
            {
                return false;
            }

            return true;
        }

        private int SumOfPhoneNumber(string phoneNumber)
        {
            if (String.IsNullOrWhiteSpace(phoneNumber))
            {
                return 0;
            }

            var sum = 0;

            foreach (char c in phoneNumber)
            {
                if (Int32.TryParse(c.ToString(), out int number))
                {
                    sum += number;
                }
            }

            return sum;
        }

        public PhoneNumber[] fetchMockData()
        {
            var a = new PhoneNumber("0865596734");
            a.PhoneNumberPrefix = new PhoneNumberPrefix("036", true);

            var b = new PhoneNumber("0362892891");
            b.PhoneNumberPrefix = new PhoneNumberPrefix("036", false);

            var c = new PhoneNumber("0972656737");
            c.PhoneNumberPrefix = new PhoneNumberPrefix("036", true);

            var d = new PhoneNumber("0362892891");
            d.PhoneNumberPrefix = new PhoneNumberPrefix("036", false);

            return new PhoneNumber[]
            {
                a, b, c, d
            };
        }
    }
}
