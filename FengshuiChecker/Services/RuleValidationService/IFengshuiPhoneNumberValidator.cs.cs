using FengshuiChecker.Console.Models;
using FengshuiChecker.Console.Services.ValidationRuleService;

namespace FengshuiChecker.Console.Services.RuleValidationService;

public interface IFengshuiPhoneNumberValidator
{
    /// <summary>
    /// Add validation rule
    /// </summary>
    /// <param name="ruleValidation"></param>
    void AddRuleValidation(IRuleValidationService ruleValidation);

    /// <summary>
    /// Check if phone number passes validation rule
    /// </summary>
    /// <param name="phoneNumber"></param>
    /// <returns>True if phone number passes all validation rules, otherwise false</returns>
    bool Validate(PhoneNumber phoneNumber);
}
