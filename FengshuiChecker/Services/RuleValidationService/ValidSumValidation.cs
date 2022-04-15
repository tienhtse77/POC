using FengshuiChecker.Console.Interfaces;
using FengshuiChecker.Console.Models;
using FengshuiChecker.Console.ViewModels.Configuration;
using Newtonsoft.Json;
using System.Reflection;

namespace FengshuiChecker.Console.Services.ValidationRuleService;

public class ValidSumValidation : IRuleValidationService
{
    public bool Validate(PhoneNumber phoneNumber)
    {
        // Parse fengshui condition configuration
        string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"fengshuiCondition.json");
        var fengshuiConfig = JsonConvert.DeserializeObject<FengshuiConfiguration>(File.ReadAllText(path));

        if (fengshuiConfig == null)
        {
            return true;
        }

        if (phoneNumber == null || String.IsNullOrWhiteSpace(phoneNumber.Value))
        {
            return false;
        }

        var first5Characters = phoneNumber.Value.Substring(0, 5);
        var last5Characters = phoneNumber.Value.Substring(phoneNumber.Value.Length - 5);

        var sumFirst5Characters = SumOfPhoneNumber(first5Characters);
        var sumLast5Characters = SumOfPhoneNumber(last5Characters);

        if (sumFirst5Characters < fengshuiConfig.MinSumFirst5Numbers || sumFirst5Characters > fengshuiConfig.MaxSumFirst5Numbers
            || sumLast5Characters < fengshuiConfig.MinSumLast5Numbers || sumLast5Characters > fengshuiConfig.MaxSumLast5Numbers)
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
}
