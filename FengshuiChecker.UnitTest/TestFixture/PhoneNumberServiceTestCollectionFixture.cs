using Autofac;
using FengshuiChecker.Console.Interfaces;
using FengshuiChecker.Console.Services.PhoneNumberService;
using Moq;
using System;

namespace FengshuiChecker.UnitTest.TestFixture;

public class PhoneNumberServiceTestCollectionFixture : IDisposable
{
    public IContainer Container { get; private set; }

    public Mock<IUnitOfWork> MockUnitOfWork { get; set; }

    public Mock<IFengshuiPhoneNumberValidator> MockFengshuiPhoneNumberValidator { get; set; }

    public PhoneNumberServiceTestCollectionFixture()
    {
        // Register all DI need for unit test.
        var builder = new ContainerBuilder();

        MockUnitOfWork = new Mock<IUnitOfWork>();
        MockFengshuiPhoneNumberValidator = new Mock<IFengshuiPhoneNumberValidator>();

        builder.RegisterType<PhoneNumberService>().As<IPhoneNumberService>()
            .WithParameter(new TypedParameter(typeof(IUnitOfWork), MockUnitOfWork.Object))
            .WithParameter(new TypedParameter(typeof(IFengshuiPhoneNumberValidator), MockFengshuiPhoneNumberValidator.Object));

        // Build container
        Container = builder.Build();
    }

    public void Dispose()
    {
    }
}
