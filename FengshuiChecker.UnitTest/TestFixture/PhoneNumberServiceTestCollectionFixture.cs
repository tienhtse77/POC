using Autofac;
using FengshuiChecker.Console.Interfaces;
using FengshuiChecker.Console.Services.PhoneNumberService;
using Moq;
using System;

namespace FengshuiChecker.UnitTest.TestFixture;

public class PhoneNumberServiceTestCollectionFixture : IDisposable
{
    public IContainer Container { get; private set; }

    public Mock<IPhoneNumberRepository> MockPhoneNumberRepository { get; set; }

    public Mock<IFengshuiPhoneNumberValidator> MockFengshuiPhoneNumberValidator { get; set; }

    public PhoneNumberServiceTestCollectionFixture()
    {
        // Register all DI need for unit test.
        var builder = new ContainerBuilder();

        MockPhoneNumberRepository = new Mock<IPhoneNumberRepository>();
        MockFengshuiPhoneNumberValidator = new Mock<IFengshuiPhoneNumberValidator>();

        builder.RegisterType<PhoneNumberService>().As<IPhoneNumberService>()
            .WithParameter(new TypedParameter(typeof(IPhoneNumberRepository), MockPhoneNumberRepository.Object))
            .WithParameter(new TypedParameter(typeof(IFengshuiPhoneNumberValidator), MockFengshuiPhoneNumberValidator.Object));

        // Build container
        Container = builder.Build();
    }

    public void Dispose()
    {
    }
}
