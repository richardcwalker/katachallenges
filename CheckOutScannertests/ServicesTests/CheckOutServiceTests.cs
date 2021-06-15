using CheckOutScanner.Helpers;
using CheckOutScanner.Services.CheckOutService;
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
    public class CheckOutServiceTests : TestBase
    {

        [Test]
        public void CheckOutServiceConstructorTest()
        {
            CheckOutService checkOutService = new CheckOutService();
            Assert.IsNotNull(checkOutService);
        }

        [Test]
        [Ignore("To implement")]
        public void CheckOutServiceScan()
        {
            //Helper -> Service
            CheckOutHelper checkOutServiceHelper = new CheckOutHelper();
            //checkOutService.ScanItem
            Assert.Inconclusive();
        }
    }
}
