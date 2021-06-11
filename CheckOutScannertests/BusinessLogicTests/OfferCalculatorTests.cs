using CheckOutScanner.BusinessLogic;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutScannertests.BusinessLogicTests
{
    [TestFixture]
    public class OfferCalculatorTests
    {
        [Test]
        public void OfferCalculatorConstructorTest()
        {
            OfferCalculator offerCalculator = new OfferCalculator();
            Assert.IsNotNull(offerCalculator);
        }
    }
}
