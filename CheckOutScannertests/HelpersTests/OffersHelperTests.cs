using CheckOutScanner.Helpers;
using CheckOutScanner.Services;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutScannertests.HelpersTests
{
    [TestFixture]
    public class OffersHelperTests
    {
        [Test]
        public void OffersHelperConstructorTest()
        {
            OffersHelper offersHelper = new OffersHelper(new OffersService());
            Assert.IsNotNull(offersHelper);
        }

        [Test]
        public void GetOffersTable()
        {
            OffersHelper offersHelper = new OffersHelper(new OffersService());
            var tableOfOffers = offersHelper.GetOffersPriceTable();
            Assert.IsNotNull(tableOfOffers);
        }
    }
}
