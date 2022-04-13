using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengshuiChecker.Models
{
    public class PhoneNumberPrefix : BaseEntity
    {
        public PhoneNumberPrefix(string value)
        {
            this.Value = value;
        }

        public string Value { get; set; }

        public virtual ICollection<PhoneNumber>? PhoneNumbers { get; set; }
    }
}
