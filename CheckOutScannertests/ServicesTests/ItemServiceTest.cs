using CheckOutScanner.Models;
using CheckOutScanner.Services.ItemService;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutScannerTests.ServicesTests
{
    /// <summary>
    //SKU  Unit Price
    //A99  0.50
    //B15  0.30
    //C40  0.60

    //Special Offers:
    //SKU  Quantity  Offer Price
    //A99  3	     1.30
    //B15  2	     0.45

    /// </summary>
    [TestFixture]
    public class ItemServiceTest : TestBase
    {
        public int ItemCount { get; set; }
        private Guid TransactionId = Guid.NewGuid();
        [SetUp]
        public void SomeClassSetUp(){}

        [TearDown]
        public void SomeTearDown()
        {

        }

        [Test]
        public void ItemServiceTestConstructorTest()
        {
            ItemService offersService = new ItemService(); ;
            Assert.IsNotNull(offersService);
        }

        [Test]
        [Category("Invalid Scan")]
        public void PassNullSKU()
        {
            ItemService itemService = new ItemService();

            isSKUOnSystem = itemService.AddScannedItem(TransactionId, null);

            Assert.IsFalse(isSKUOnSystem);
        }

        [Test]
        [Category("Invalid Scan")]
        public void PassEmptySKU()
        {
            ItemService itemService = new ItemService();

            isSKUOnSystem = itemService.AddScannedItem(TransactionId, EMPTY_SKU_ID);

            Assert.IsFalse(isSKUOnSystem);
        }

        [Test]
        [Description("Test to see if a SKU IS NOT on the system is reported / logged correctly")]
        [Category("Invalid Scan")]
        public void ScanSKUNotOnSystem()
        {
            ItemService itemService = new ItemService();

            isSKUOnSystem = itemService.AddScannedItem(TransactionId, INVALID_SKU_ID);

            Assert.IsFalse(isSKUOnSystem, "SKU exists. This test is needed to check for MISSING SKUs on the system");
        }

        [Test]
        [Description("Add a single valid SKU")]
        [Category("Valid Scan")]
        public void ScanValidSKU()
        {
            ItemService itemService = new ItemService();
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_A99);
            Assert.IsTrue(isSKUOnSystem);
        }

        [Test]
        [Description("Add multiple valid SKUs")]
        [Category("Valid Scan")]
        public void ScanMultipleSKUs()
        {
            ItemService itemService = new ItemService();
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_C40);
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_A99);
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_B15);
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_A99);
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_A99);
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_B15);
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_C40);
            Assert.IsTrue(isSKUOnSystem);
        }

        [Test]
        [Description("Get totals of 4 apples. We should return 1.80 as the total (1.30 offer for 3 and one apple at 0.5)")]
        [Category("Valid Totalizer")]
        public void ScanApplesReturnOfferValuePlusOneFullPrice()
        {
            ItemService itemService = new ItemService();
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_A99);
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_A99);
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_A99);
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_A99);
            decimal totalCost = itemService.GetTotalPriceOfItems(transactionID: TransactionId);
            Assert.AreEqual(1.80, totalCost);
        }

        [Test]
        [Description("Get totals of 2 apples. We should return 1.00 as the total")]
        [Category("Valid Totalizer")]
        public void ApplesNoOffer()
        {
            ItemService itemService = new ItemService();
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_A99);
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_A99);
            decimal totalCost = itemService.GetTotalPriceOfItems(transactionID: TransactionId);
            Assert.AreEqual(1.00, totalCost);
        }

        [Test]
        [Description("Two biscuits and one carrot should equal 1.05")]
        [Category("Valid Totalizer")]
        public void BiscuitsOffer()
        {
            ItemService itemService = new ItemService();
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_B15); 
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_B15); //.45 
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_C40); //.6
            decimal totalCost = itemService.GetTotalPriceOfItems(transactionID: TransactionId);
            Assert.AreEqual(1.05, totalCost);
        }

        [Test]
        [Description("Two biscuits, one carrot, one biscuit should equal 1.05")]
        [Category("Valid Totalizer")]
        public void TwoBiscuitsOneCarrotOneMoreBiscuit()
        {
            ItemService itemService = new ItemService();
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_B15);
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_B15); //.45 
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_C40); //.6
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_B15); //.30
            decimal totalCost = itemService.GetTotalPriceOfItems(transactionID: TransactionId);
            Assert.AreEqual(1.35, totalCost);
        }

        [Test]
        [Description("Four biscuits and one carrot should equal 1.50(carrot scanned in the middle)")]
        [Category("Valid Totalizer")]
        public void OneBiscuitOneAppleOneBiscuitScenarioForSpec()
        {
            ItemService itemService = new ItemService();
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_B15);
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_A99); 
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_B15);
            decimal totalCost = itemService.GetTotalPriceOfItems(transactionID: TransactionId);
            Assert.AreEqual(0.95, totalCost);
        }

        [Test]
        [Description("Four biscuits and one carrot should equal 1.50(carrot scanned in the middle)")]
        [Category("Valid Totalizer")]
        public void TwoPairsOfBiscuitsOffered()
        {
            ItemService itemService = new ItemService();
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_B15);
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_B15); //.45 
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_C40); //.6
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_B15);
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_B15); //.45 
            decimal totalCost = itemService.GetTotalPriceOfItems(transactionID: TransactionId);
            Assert.AreEqual(1.50, totalCost);
        }

        [Test]
        [Description("Carrots not on offer so scan 4 and return total of 1.80")]
        [Category("Valid Totalizer")]
        public void CarrotsNoOffer()
        {
            ItemService itemService = new ItemService();
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_C40); //.6
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_C40); //.6
            isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_C40); //.6
            decimal totalCost = itemService.GetTotalPriceOfItems(transactionID: TransactionId);
            Assert.AreEqual(1.80, totalCost);
        }
    }
}
