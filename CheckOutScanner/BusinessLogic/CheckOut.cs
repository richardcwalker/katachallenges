using CheckOutScanner.Helpers;
using CheckOutScanner.Models;

namespace CheckOutScanner.BusinessLogic
{
    public class Checkout : BusinessLogicBase
    {
        private ItemHelper itemHelper;
        public Checkout()
        {
        }

        /// <summary>
        /// Scanner would pass each item and return true to the UI if Ok else false.
        /// </summary>
        /// <param name="SKUBeingScanned"></param>
        public bool Scan(string SKUBeingScanned)
        {
            return itemHelper.AddItem(SKUBeingScanned);
        }

        /// <summary>
        /// Call the Item Service to do the work
        /// </summary>
        /// <param name="itemAdded"></param>
        /// <returns></returns>
        private Item AddItem(Item itemAdded)
        {
            return itemAdded;
        }
    }
}
