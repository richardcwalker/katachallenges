using CheckOutScanner.BusinessLogic;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutScannerTests.BusinessLogicTests
{
    [TestFixture]
    public class CheckOutTests : TestBase
    {
        private Guid TransactionId = Guid.NewGuid();
        [SetUp]
        [Test]
        public void CheckOutConstructorTest()
        {
            Checkout checkOut = new Checkout();
            Assert.IsNotNull(checkOut);
        }

        [Test]
        public void NoSKUPassed()
        {
            Checkout checkOut = new Checkout();
            hasItemScanned = checkOut.ScanItem(TransactionId, EMPTY_SKU_ID);
            Assert.IsFalse(hasItemScanned);
        }

        [Test]
        public void ScanOneValidSKUItem()
        {
            Checkout checkOut = new Checkout();
            hasItemScanned = checkOut.ScanItem(TransactionId, VALID_SKU_ID_A99);
            Assert.IsTrue(hasItemScanned);
        }

        [Test]
        public void ScanOneInValidSKUItem()
        {
            Checkout checkOut = new Checkout();
            hasItemScanned = checkOut.ScanItem(TransactionId, INVALID_SKU_ID);
            Assert.IsFalse(hasItemScanned);
        }

        [Test]
        [Description("Get totals of 4 apples. We should return 1.80 as the total (1.30 offer for 3 and one apple at 0.5)")]
        [Category("Valid Totalizer")]
        public void ScanFourApplesOfferApplied()
        {
            Checkout checkOut = new Checkout();
            hasItemScanned = checkOut.ScanItem(TransactionId, VALID_SKU_ID_A99);
            hasItemScanned = checkOut.ScanItem(TransactionId, VALID_SKU_ID_A99);
            hasItemScanned = checkOut.ScanItem(TransactionId, VALID_SKU_ID_A99);
            hasItemScanned = checkOut.ScanItem(TransactionId, VALID_SKU_ID_A99);
            decimal totalCost = checkOut.GetTotalPriceOfItems(transactionID: TransactionId);
            Assert.AreEqual(1.80, totalCost);
        }

        [Test]
        [Description("Get totals of 2 apples. We should return 1.80 as the total (1.30 offer for 3 and one apple at 0.5)")]
        [Category("Valid Totalizer")]
        public void ScanTwoBiscuitsOfferApplied()
        {
            Checkout checkOut = new Checkout();
            hasItemScanned = checkOut.ScanItem(TransactionId, VALID_SKU_ID_B15);
            hasItemScanned = checkOut.ScanItem(TransactionId, VALID_SKU_ID_B15);
            hasItemScanned = checkOut.ScanItem(TransactionId, VALID_SKU_ID_C40);
            decimal totalCost = checkOut.GetTotalPriceOfItems(transactionID: TransactionId);
            Assert.AreEqual(1.05, totalCost);
        }

        [Test]
        [Description("Carrots not on offer so scan 4 and return total of 1.80")]
        [Category("Valid Totalizer")]
        public void CarrotsNoOffer()
        {

            Checkout checkOut = new Checkout();
            hasItemScanned = checkOut.ScanItem(TransactionId, VALID_SKU_ID_C40);
            hasItemScanned = checkOut.ScanItem(TransactionId, VALID_SKU_ID_C40);
            hasItemScanned = checkOut.ScanItem(TransactionId, VALID_SKU_ID_C40);
            decimal totalCost = checkOut.GetTotalPriceOfItems(transactionID: TransactionId);
            Assert.AreEqual(1.80, totalCost);
        }

        [Test]
        [Description("SCENARIO FROM THE SPEC : The checkout accepts items scanned in any order, so that if we scan a pack of Biscuits (B15), " +
            "an apple (A99) and another pack of biscuits, we’ll recognise two packs of biscuits " +
            "and apply the discount of 2 for 45. ")]
        [Category("Valid Totalizer")]
        public void BiscuitsAppleBiscuits()
        {

            Checkout checkOut = new Checkout();
            hasItemScanned = checkOut.ScanItem(TransactionId, VALID_SKU_ID_B15);
            hasItemScanned = checkOut.ScanItem(TransactionId, VALID_SKU_ID_A99);
            hasItemScanned = checkOut.ScanItem(TransactionId, VALID_SKU_ID_B15);
            decimal totalCost = checkOut.GetTotalPriceOfItems(transactionID: TransactionId);
            Assert.AreEqual(0.95, totalCost);
        }


    }
}
