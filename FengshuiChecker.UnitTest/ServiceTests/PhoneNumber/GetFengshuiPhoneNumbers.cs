using Moq;
using Xunit;
using FengshuiChecker.UnitTest.Helpers;
using FengshuiChecker.UnitTest.TestFixture;
using Autofac;
using FengshuiChecker.Console.Interfaces;
using System;

namespace FengshuiChecker.UnitTest.ServiceTests.PhoneNumber;

[Collection(TestConstantsCollection.PhoneNumberServiceTestCollectionName)]
public partial class GetFengshuiPhoneNumbers
{
    private IPhoneNumberService _phoneNumberService;
    private Mock<IUnitOfWork> _mockUnitOfWork;
    private Mock<IFengshuiPhoneNumberValidator> _mockFengshuiValidator;

    public GetFengshuiPhoneNumbers(PhoneNumberServiceTestCollectionFixture collectionFixture)
    {
        using (var scope = collectionFixture.Container.BeginLifetimeScope())
        {
            _phoneNumberService = scope.Resolve<IPhoneNumberService>();
        }

        _mockUnitOfWork = collectionFixture.MockUnitOfWork;
        _mockFengshuiValidator = collectionFixture.MockFengshuiPhoneNumberValidator;
    }

    [Fact]
    public async void GetFengshuiPhoneNumbers_Success_HasValue()
    {
        // Arrange
        var fengshuiPhoneNumber = FakeData.GenerateFengshuiPhoneNumber();
        var mockResult = new Console.Models.PhoneNumber[]
        {
            fengshuiPhoneNumber,
            fengshuiPhoneNumber
        };
        _mockUnitOfWork
            .Setup(p => p.PhoneNumberRepository.GetAllPhoneNumbers())
            .ReturnsAsync(mockResult);
        _mockFengshuiValidator
            .Setup(p => p.Validate(It.IsAny<Console.Models.PhoneNumber>()))
            .Returns(true);

        // Act
        var result = await _phoneNumberService.GetShengfuiPhoneNumbers();

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
        _mockUnitOfWork
            .Setup(p => p.PhoneNumberRepository.GetAllPhoneNumbers())
            .ReturnsAsync(mockResult);
        _mockFengshuiValidator
            .Setup(p => p.Validate(It.IsAny<Console.Models.PhoneNumber>()))
            .Returns(false);

        // Act
        var result = await _phoneNumberService.GetShengfuiPhoneNumbers();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public async void GetFengshuiPhoneNumbers_Fail_QueryThrowException()
    {
        // Arrange
        _mockUnitOfWork
            .Setup(p => p.PhoneNumberRepository.GetAllPhoneNumbers())
            .ThrowsAsync(new Exception());

        // Act
        var exception = await Record.ExceptionAsync(async () =>
            await _phoneNumberService.GetShengfuiPhoneNumbers());

        // Assert
        Assert.NotNull(exception);
    }
}
