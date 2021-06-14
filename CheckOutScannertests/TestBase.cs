using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CheckOutScannerTests
{
    public class TestBase
    {
        public TestContext _testContext { get; set; }

        protected const string VALID_SKU_ID_A99 = "A99"; //Apple 
        protected const string VALID_SKU_ID_B15 = "B15"; //Biscuits 
        protected const string VALID_SKU_ID_C40 = "C40"; //Carrots

        protected const string EMPTY_SKU_ID = ""; //No SKU Added
        protected const string INVALID_SKU_ID = "Z99"; //No Product Exists
        protected bool isSKUOnSystem;

        protected void WriteDescription(Type typ)
        {
            string testName = TestContext.CurrentContext.Test.Name;

            //Find the method currently executing
            MemberInfo method = typ.GetMethod(testName);
            if (method != null) {
                // See if the [Description] attribute exists on this test
                Attribute attr = method.GetCustomAttribute(
                    typeof(DescriptionAttribute));
                if (attr != null)
                {
                    //Cast the attribute to a DescriptionAttribute
                    DescriptionAttribute dattr = (DescriptionAttribute)attr;
                    //Display the test description
                    TestContext.Out.WriteLine("Test Description: " + dattr);
                }
            }
        }
    }

    
}
