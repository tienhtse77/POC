namespace FengshuiChecker.Console.Services.PhoneNumberService;

public interface IPhoneNumberService
{
    /// <summary>
    /// Get all shengfui phone numbers
    /// </summary>
    /// <returns>An array of phone numbers</returns>
    Task<string[]> GetShengfuiPhoneNumbers();
}
