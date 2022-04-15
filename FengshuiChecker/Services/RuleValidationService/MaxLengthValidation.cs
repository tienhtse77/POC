using FengshuiChecker.Console.Extensions;
using FengshuiChecker.Console.Interfaces;
using FengshuiChecker.Console.Models;

namespace FengshuiChecker.Console.Services.ValidationRuleService;

public class MaxLengthValidation : IRuleValidationService
{
    public bool Validate(PhoneNumber phoneNumber)
    {
        var fengshuiConfig = ConfigurationReader.LoadConfiguration();

        if (fengshuiConfig == null)
        {
            return true;
        }

        if (phoneNumber == null || String.IsNullOrWhiteSpace(phoneNumber.Value))
        {
            return false;
        }

        if (phoneNumber.Value.GetNumeric().Length > fengshuiConfig.MaxLength)
        {
            return false;
        }

        return true;
    }
}
