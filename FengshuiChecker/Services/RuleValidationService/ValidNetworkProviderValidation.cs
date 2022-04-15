using FengshuiChecker.Console.Extensions;
using FengshuiChecker.Console.Interfaces;
using FengshuiChecker.Console.Models;

namespace FengshuiChecker.Console.Services.ValidationRuleService;

public class ValidNetworkProviderValidation : IRuleValidationService
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

        if (phoneNumber.PhoneNumberPrefix?.IsFengshuiPrefix == false)
        {
            return false;
        }

        return true;
    }
}
