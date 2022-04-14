using FengshuiChecker.Models;
using FengshuiChecker.Services.ValidationRuleService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengshuiChecker.Services.RuleValidationService
{
    public class FengshuiPhoneNumberValidator : IFengshuiPhoneNumberValidator
    {
        private IList<IRuleValidationService> ruleValidations;

        public void AddRuleValidation(IRuleValidationService ruleValidation)
        {
            if (this.ruleValidations == null)
            {
                this.ruleValidations = new List<IRuleValidationService>(); 
            }

            this.ruleValidations.Add(ruleValidation);
        }

        public bool Validate(PhoneNumber phoneNumber)
        {
            if (this.ruleValidations == null || this.ruleValidations.Count == 0)
            {
                return true;
            }

            foreach (var validator in this.ruleValidations)
            {
                var isValid = validator.Validate(phoneNumber);

                if (isValid == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
