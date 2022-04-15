using FengshuiChecker.Console.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FengshuiChecker.UnitTest.TestFixture
{
    public class PhoneNumberServiceTestFixture
    {
        public Mock<IUnitOfWork> MockUnitOfWork { get; private set; }

        public PhoneNumberServiceTestFixture()
        {
            MockUnitOfWork = new Mock<IUnitOfWork>();
        }
    }
}
