using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengshuiChecker.Services.PhoneNumberService
{
    public interface IPhoneNumberService
    {
        /// <summary>
        /// Get all shengfui phone numbers
        /// </summary>
        /// <returns>An array of phone numbers</returns>
        Task<string[]> GetShengfuiPhoneNumbers();
    }
}
