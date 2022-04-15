namespace FengshuiChecker.Console.Models;

public class PhoneNetworkProvider : BaseEntity
{
    public PhoneNetworkProvider(string name)
    {
        this.Name = name;
    }

    public bool IsFengshuiType { get; set; }

    public string Name { get; set; }

    public virtual ICollection<PhoneNumberPrefix>? PhoneNumberPrefixes { get; set; }
}
