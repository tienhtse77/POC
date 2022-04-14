using FengshuiChecker.Models;
using FengshuiChecker.Repositories;
using FengshuiChecker.Services.RuleValidationService;
using FengshuiChecker.Services.ValidationRuleService;
using FengshuiChecker.ViewModels.Configuration;
using Newtonsoft.Json;
using System.Reflection;

namespace FengshuiChecker.Services.PhoneNumberService
{
    public class PhoneNumberService : IPhoneNumberService
    {
        private readonly IUnitOfWork _uow;
        private readonly IFengshuiPhoneNumberValidator _validator;

        public PhoneNumberService(IUnitOfWork uow, IFengshuiPhoneNumberValidator validator)
        {
            this._uow = uow;
            this._validator = validator;
        }

        public async Task<string[]> GetShengfuiPhoneNumbers()
        {
            try
            {
                SetUpFengshuiValidator(this._validator);
                var phoneNumbers = await _uow.PhoneNumberRepository.GetAllPhoneNumbers();

                if (phoneNumbers.Length == 0)
                {
                    return new string[0];
                }
                
                var result = new List<string>();

                foreach (var phoneNumber in phoneNumbers)
                {
                    if (this._validator.Validate(phoneNumber))
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

        private void SetUpFengshuiValidator(IFengshuiPhoneNumberValidator validator)
        {
            if (validator == null)
            {
                return;
            }

            validator.AddRuleValidation(new MaxLengthValidation());
            validator.AddRuleValidation(new LastTwoNumberValidation());
            validator.AddRuleValidation(new ValidNetworkProviderValidation());
            validator.AddRuleValidation(new ValidSumValidation());
        }
    }
}
