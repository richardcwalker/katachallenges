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
        public void ScanMultipleSKUsAndScan()
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

        //[Test]
        //[Description("Get totals of all out added items / SKUs")]
        //[Category("Valid Totalizer")]
        //public void ScanMultipleSKUsScanAndRequestTotal()
        //{
        //    ItemService itemService = new ItemService();
        //    isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_C40);
        //    isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_A99);
        //    isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_B15);
        //    isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_A99);
        //    isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_A99);
        //    isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_B15);
        //    isSKUOnSystem = itemService.AddScannedItem(TransactionId, VALID_SKU_ID_C40);
        //    decimal totalCost = itemService.GetTotalPriceOfItems("sometrandasctionid");
        //}
    }
}
