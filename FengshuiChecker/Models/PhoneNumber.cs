namespace FengshuiChecker.Console.Models;

public class PhoneNumber : BaseEntity
{
    public PhoneNumber(string value)
    {
        this.Value = value;
    }

    public string Value { get; set; }

    public Guid? PhoneNumberPrefixId { get; set; }

    public virtual PhoneNumberPrefix? PhoneNumberPrefix { get; set; }
}
