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
        [SetUp] 
        public void SomeClassSetUp()
        {
            ItemCount = 0;


        }

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
        public void GetItemCostPriceTable()
        {
            ItemService itemService = new ItemService();
            IDictionary<string, decimal> itemCostTable = itemService.GetItemCostPriceTable();

            Assert.IsTrue(true);
        }

        [Test]
        public void PassNullSKU()
        {
            ItemService itemService = new ItemService();

            isSKUOnSystem = itemService.AddScannedItem(null);

            Assert.IsFalse(isSKUOnSystem);
        }

        [Test]
        public void PassEmptySKU()
        {
            ItemService itemService = new ItemService();

            isSKUOnSystem = itemService.AddScannedItem(EMPTY_SKU_ID);

            Assert.IsFalse(isSKUOnSystem);
        }

        [Test]
        public void AddInValidItemScanned()
        {
            ItemService itemService = new ItemService();
            
            isSKUOnSystem = itemService.AddScannedItem(INVALID_SKU_ID);

            Assert.IsFalse(isSKUOnSystem);
        }

        [Test]
        public void AddValidItemScanned()
        {
            ItemService itemService = new ItemService();
            isSKUOnSystem = itemService.AddScannedItem(VALID_SKU_ID_A99);

            Assert.IsTrue(isSKUOnSystem);
        }


    }
}
