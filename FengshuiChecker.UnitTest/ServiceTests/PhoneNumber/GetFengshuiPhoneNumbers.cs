using Moq;
using Xunit;
using FengshuiChecker.Console.Repositories;
using FengshuiChecker.UnitTest.Helpers;
using FengshuiChecker.UnitTest.TestFixture;

namespace FengshuiChecker.UnitTest.ServiceTests.PhoneNumber
{
    public class GetFengshuiPhoneNumbers : IClassFixture<PhoneNumberServiceTestFixture>
    {
        private IUnitOfWork _uow;
        PhoneNumberServiceTestFixture fixture;

        public GetFengshuiPhoneNumbers(PhoneNumberServiceTestFixture fixture, IUnitOfWork uow)
        {
            this.fixture = fixture;
            this._uow = uow;
        }

        [Fact]
        public async void GetFengshuiPhoneNumbers_Success_HasValue()
        {
            // Arrange
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            var fengshuiPhoneNumber = FakeData.GenerateFengshuiPhoneNumber();
            var mockResult = new Console.Models.PhoneNumber[]
            {
                fengshuiPhoneNumber,
                fengshuiPhoneNumber
            };
            mock.Setup(p => p.PhoneNumberRepository.GetAllPhoneNumbers())
                .ReturnsAsync(new Console.Models.PhoneNumber[] { fengshuiPhoneNumber });

            // Act
            var result = await this._uow.PhoneNumberRepository.GetAllPhoneNumbers();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(mockResult.Length, result.Length);
        }

        [Fact]
        public async void GetFengshuiPhoneNumbers_Success_NoValue()
        {
            // Arrange
            var fengshuiPhoneNumber = FakeData.GenerateNonFengshuiPhoneNumber();
            var mockResult = new Console.Models.PhoneNumber[]
            {
                fengshuiPhoneNumber,
                fengshuiPhoneNumber
            };
            fixture.MockUnitOfWork
                .Setup(p => p.PhoneNumberRepository.GetAllPhoneNumbers())
                .ReturnsAsync(mockResult);

            // Act
            var result = await this._uow.PhoneNumberRepository.GetAllPhoneNumbers();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}

