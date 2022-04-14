using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengshuiChecker.Models
{
    public class PhoneNumberPrefix : BaseEntity
    {
        public PhoneNumberPrefix(string value, bool isFengshuiType)
        {
            this.Value = value;
            this.IsFengshuiType = isFengshuiType;
        }

        public string Value { get; set; }

        public bool IsFengshuiType { get; set; }

        public virtual ICollection<PhoneNumber>? PhoneNumbers { get; set; }
    }
}
