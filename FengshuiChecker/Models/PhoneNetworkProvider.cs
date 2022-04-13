using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengshuiChecker.Models
{
    public class PhoneNetworkProvider : BaseEntity
    {
        public PhoneNetworkProvider(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public virtual ICollection<PhoneNumberPrefix>? PhoneNumberPrefixes { get; set; }
    }
}
