using FengshuiChecker.Console.Models;
using FengshuiChecker.Console.ViewModels.Configuration;
using Newtonsoft.Json;
using System.Reflection;

namespace FengshuiChecker.Console.Services.ValidationRuleService;

public class ValidNetworkProviderValidation : IRuleValidationService
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

        if (phoneNumber.PhoneNumberPrefix?.IsFengshuiType == false)
        {
            return false;
        }

        return true;
    }
}
