namespace FengshuiChecker.Console.Models;

public class PhoneNumberPrefix : BaseEntity
{
    public PhoneNumberPrefix() { }

    public PhoneNumberPrefix(string value, bool isFengshuiPrefix)
    {
        this.Value = value;
        this.IsFengshuiPrefix = isFengshuiPrefix;
    }

    public string Value { get; set; }

    public bool IsFengshuiPrefix { get; set; }

    public virtual ICollection<PhoneNumber>? PhoneNumbers { get; set; }
}
