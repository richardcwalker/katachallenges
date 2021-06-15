using CheckOutScanner.Helpers;
using CheckOutScanner.Models;
using CheckOutScanner.Services.ItemService;
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
        private Guid TransactionId;
        [SetUp]
        public void SomeClassSetUp()
        {
            TransactionId = new Guid();
        }
        [Test]
        [Ignore("To implement")]
        public void ItemHelpersConstructorTest()
        {
            ItemHelper itemHelper = new ItemHelper(new ItemService());
            Assert.IsNotNull(itemHelper);
        }

        [Test]
        [Ignore("To implement")]
        public void AddItemErrorTest()
        {
            ItemHelper itemHelper = new ItemHelper(new ItemService());
            Assert.IsFalse(itemHelper.AddItem(TransactionId,null));
        }

        [Test]
        [Ignore("To implement")]
        public void AddOneItemTest()
        {
            Item item = new Item();
            item.SKU = "A99";
            item.UnitPrice = 0.05m;
            ItemHelper itemHelper = new ItemHelper(new ItemService());
            Assert.IsTrue(itemHelper.AddItem(TransactionId,VALID_SKU_ID_A99));
        }
    }
}
