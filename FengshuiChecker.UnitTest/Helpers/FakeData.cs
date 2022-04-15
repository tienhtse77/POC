using Bogus;
using FengshuiChecker.Console.Models;
using System.Linq;

namespace FengshuiChecker.UnitTest.Helpers
{
    public static class FakeData
    {
        public static PhoneNumber GenerateFengshuiPhoneNumber()
        {
            var phoneNumber = new PhoneNumber("0972656737");
            phoneNumber.PhoneNumberPrefix = new PhoneNumberPrefix("097", true);
            return phoneNumber;
        }

        public static PhoneNumber GenerateNonFengshuiPhoneNumber()
        {
            var phoneNumber = new PhoneNumber("0362892891");
            phoneNumber.PhoneNumberPrefix = new PhoneNumberPrefix("036", false);
            return phoneNumber;
        }
    }
}
