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
    public class CheckOutHelper
    {
        [Test]
        public void CheckOutHelperConstructorTest()
        {
            CheckOutHelper itemHelper = new CheckOutHelper();
            Assert.IsNotNull(itemHelper);
        }

    }
}
