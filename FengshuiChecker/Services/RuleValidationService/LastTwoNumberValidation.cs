using FengshuiChecker.Console.Extensions;
using FengshuiChecker.Console.Interfaces;
using FengshuiChecker.Console.Models;

namespace FengshuiChecker.Console.Services.ValidationRuleService;

public class LastTwoNumberValidation : IRuleValidationService
{
    public bool Validate(PhoneNumber phoneNumber)
    {
        var fengshuiConfig = ConfigurationReader.LoadConfiguration();

        if (fengshuiConfig == null)
        {
            return true;
        }

        if (fengshuiConfig.ValidLastNumbers == null || fengshuiConfig.ValidLastNumbers.Length == 0)
        {
            return false;
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

        var lastTwoCharacters = sanitizedPhoneNumber.Substring(sanitizedPhoneNumber.Length - 2);

        if (fengshuiConfig.ValidLastNumbers.Contains(lastTwoCharacters))
        {
            return true;
        }

        return false;
    }
}
