using CheckOutScanner.Helpers;
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
    public class ItemHelperTests
    {
        [Test]
        public void ItemHelpersConstructorTest()
        {
            ItemHelper itemHelper = new ItemHelper();
            Assert.IsNotNull(itemHelper);
        }
    }
}
