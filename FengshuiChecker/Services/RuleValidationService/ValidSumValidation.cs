using FengshuiChecker.Console.Extensions;
using FengshuiChecker.Console.Interfaces;
using FengshuiChecker.Console.Models;

namespace FengshuiChecker.Console.Services.ValidationRuleService;

public class ValidSumValidation : IRuleValidationService
{
    public bool Validate(PhoneNumber phoneNumber)
    {
        var fengshuiConfig = ConfigurationReader.LoadConfiguration();

        if (fengshuiConfig == null)
        {
            return true;
        }

        if (phoneNumber == null)
        {
            return false;
        }

        var sanitizedPhoneNumber = phoneNumber.Value.GetNumeric();

        if (sanitizedPhoneNumber.Length != 10)
        {
            return false;
        }

        var first5Characters = sanitizedPhoneNumber.Substring(0, 5);
        var last5Characters = sanitizedPhoneNumber.Substring(sanitizedPhoneNumber.Length - 5);

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
