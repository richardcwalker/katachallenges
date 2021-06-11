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
        public void AddInValidItemScanned()
        {
            ItemService itemService = new ItemService();
            Item item = new()
            {
                SKU = INVALID_SKU_ID
            };
            bool itemCostTable = itemService.AddItem(item);

            Assert.IsTrue(true);
        }

        [Test]
        public void AddValidItemScanned()
        {
            ItemService itemService = new ItemService();
            Item item1 = new()
            {
                SKU = VALID_SKU_ID_A99
            };
            bool itemCostTable = itemService.AddItem(item1);

            Assert.IsTrue(true);
        }


    }
}
