using CheckOutScanner.Helpers;
using CheckOutScanner.Models;
using CheckOutScanner.Services;
using CheckOutScannerTests;
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
    public class ItemHelperTests : TestBase
    {
        private ItemHelper itemHelper;

        [Test]
        public void ItemHelpersConstructorTest()
        {
            ItemHelper itemHelper = new ItemHelper(new ItemService());
            Assert.IsNotNull(itemHelper);
        }

        [Test]
        public void AddItemErrorTest()
        {
            ItemHelper itemHelper = new ItemHelper(new ItemService());
            Assert.IsFalse(itemHelper.AddItem(null));
        }

        [Test]
        public void AddOneItemTest()
        {
            Item item = new Item();
            item.SKU = "A99";
            item.UnitPrice = 0.05m;
            ItemHelper itemHelper = new ItemHelper(new ItemService());
            Assert.IsTrue(itemHelper.AddItem(item));
        }
    }
}
