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
    public class CheckOutHelperTests
    {
        [Test]
        public void CheckOutHelperConstructorTest()
        {
            CheckOutHelperTests itemHelper = new CheckOutHelperTests();
            Assert.IsNotNull(itemHelper);
        }

    }
}
