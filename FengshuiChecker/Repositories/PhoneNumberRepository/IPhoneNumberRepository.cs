using FengshuiChecker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengshuiChecker.Repositories.PhoneNumberRepository
{
    public interface IPhoneNumberRepository : IGenericRepository<PhoneNumber>
    {
        /// <summary>
        /// Get all active phone numbers
        /// </summary>
        /// <returns>An array of phone numbers</returns>
        Task<PhoneNumber[]> GetAllPhoneNumbers();
    }
}
