using FengshuiChecker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengshuiChecker.Services.ValidationRuleService
{
    public interface IRuleValidationService
    {
        /// <summary>
        /// Check if phone number is valid
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns>True if phone number is valid, otherwise false</returns>
        bool Validate(PhoneNumber phoneNumber);
    }
}
