using FengshuiChecker.Console.Models;

namespace FengshuiChecker.Console.Interfaces;

public interface IRuleValidationService
{
    /// <summary>
    /// Check if phone number is valid
    /// </summary>
    /// <param name="phoneNumber"></param>
    /// <returns>True if phone number is valid, otherwise false</returns>
    bool Validate(PhoneNumber phoneNumber);
}
