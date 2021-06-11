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
    public class ItemServiceTest
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

        
    }
}
