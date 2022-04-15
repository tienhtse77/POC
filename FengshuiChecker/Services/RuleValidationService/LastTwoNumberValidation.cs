using FengshuiChecker.Console.Interfaces;
using FengshuiChecker.Console.Models;
using FengshuiChecker.Console.ViewModels.Configuration;
using Newtonsoft.Json;
using System.Reflection;

namespace FengshuiChecker.Console.Services.ValidationRuleService;

public class LastTwoNumberValidation : IRuleValidationService
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

        if (fengshuiConfig.ValidLastNumbers == null || fengshuiConfig.ValidLastNumbers.Length == 0)
        {
            return false;
        }

        if (phoneNumber == null || String.IsNullOrWhiteSpace(phoneNumber.Value))
        {
            return false;
        }

        var lastTwoCharacters = phoneNumber.Value.Substring(phoneNumber.Value.Length - 2);

        if (fengshuiConfig.ValidLastNumbers.Contains(lastTwoCharacters))
        {
            return true;
        }

        return false;
    }
}
