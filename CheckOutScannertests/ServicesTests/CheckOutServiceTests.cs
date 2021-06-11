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
    public class CheckOutServiceTests
    {

        [Test]
        public void CheckOutServiceConstructorTest()
        {
            CheckOutService checkOutService = new CheckOutService();
            Assert.IsNotNull(checkOutService);
        }
    }
}
