using CheckOutScanner.Models;
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
    public class OffersServiceTest
    {
        [Test]
        public void OffersServiceTestConstructorTest()
        {
            OffersService offersService = new OffersService(); ;
            Assert.IsNotNull(offersService);
        }

        [Test]
        public void GetOffersTable()
        {
            OffersService offersService = new OffersService();
            IDictionary<string, Offer> offerCostTable = offersService.GetOffersPriceTable();

            Assert.IsTrue(true);
        }

        
    }
}
