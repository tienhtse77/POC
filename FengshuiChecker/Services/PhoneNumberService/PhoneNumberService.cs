using FengshuiChecker.Console.Interfaces;
using FengshuiChecker.Console.Services.ValidationRuleService;

namespace FengshuiChecker.Console.Services.PhoneNumberService;

public class PhoneNumberService : IPhoneNumberService
{
    private readonly IFengshuiPhoneNumberValidator _validator;
    private readonly IPhoneNumberRepository _phoneNumberRepository;

    public PhoneNumberService(IFengshuiPhoneNumberValidator validator, IPhoneNumberRepository phoneNumberRepository)
    {
        this._validator = validator;
        this._phoneNumberRepository = phoneNumberRepository;
    }

    public async Task<string[]> GetShengfuiPhoneNumbers()
    {
        try
        {
            SetUpFengshuiValidator(this._validator);
            var phoneNumbers = await _phoneNumberRepository.GetAllPhoneNumbers();

            if (phoneNumbers.Length == 0)
            {
                return new string[0];
            }
                
            var result = new List<string>();

            foreach (var phoneNumber in phoneNumbers)
            {
                if (this._validator.Validate(phoneNumber))
                {
                    result.Add(phoneNumber.Value);
                }
            }

            return result.ToArray();
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
    }

    private void SetUpFengshuiValidator(IFengshuiPhoneNumberValidator validator)
    {
        if (validator == null)
        {
            return;
        }

        validator.AddRuleValidation(new MaxLengthValidation());
        validator.AddRuleValidation(new LastTwoNumberValidation());
        validator.AddRuleValidation(new ValidNetworkProviderValidation());
        validator.AddRuleValidation(new ValidSumValidation());
    }
}
