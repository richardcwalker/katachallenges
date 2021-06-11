using CheckOutScanner.Services;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutScannerTests.ServicesTests
{
    [TestFixture]
    public class ErrorHandlingServiceTests
    {
        [Test]
        public void ErrorHandlingServiceConstructorTest()
        {
            ErrorHandlingService errorHandlingService = new ErrorHandlingService();
            Assert.IsNotNull(errorHandlingService);
        }
    }
}
