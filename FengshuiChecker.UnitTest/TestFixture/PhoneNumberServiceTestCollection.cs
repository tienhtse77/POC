using FengshuiChecker.UnitTest.Helpers;
using Xunit;

namespace FengshuiChecker.UnitTest.TestFixture;

[CollectionDefinition(TestConstantsCollection.PhoneNumberServiceTestCollectionName)]
public class PhoneNumberServiceTestCollection : ICollectionFixture<PhoneNumberServiceTestCollectionFixture>
{

}
