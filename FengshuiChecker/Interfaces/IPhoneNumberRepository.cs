using FengshuiChecker.Console.Models;

namespace FengshuiChecker.Console.Interfaces;

public interface IPhoneNumberRepository : IGenericRepository<PhoneNumber>
{
    /// <summary>
    /// Get all active phone numbers
    /// </summary>
    /// <returns>An array of phone numbers</returns>
    Task<PhoneNumber[]> GetAllPhoneNumbers();
}
