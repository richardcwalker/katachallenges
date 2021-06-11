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
        //[Test]
        //public void TestMethod()
        //{
        //    // TODO: Add your test code here
        //    var answer = 42;
        //    Assert.That(answer, Is.EqualTo(42), "Some useful error message");
        //}

        [Test]
        public void ItemHelpersConstructorTest()
        {
            ItemHelpers itemHelper = new ItemHelpers();
            Assert.IsNotNull(itemHelper);
        }
    }
}
