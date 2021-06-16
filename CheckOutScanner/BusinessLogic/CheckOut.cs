using CheckOutScanner.Helpers;
using CheckOutScanner.Models;
using System;

namespace CheckOutScanner.BusinessLogic
{
    public class Checkout : BusinessLogicBase
    {
        private ItemHelper itemHelper;
        public Checkout()
        {
        }

        /// <summary>
        /// Scanner would pass each item and (optional??) Transaction ID and return true to the UI if Ok else false.
        /// </summary>
        /// <param name="SKUBeingScanned"></param>
        public bool ScanItem(Guid TransactionID, string SKUBeingScanned)
        {
            return itemHelper.AddItem(TransactionID, SKUBeingScanned);
        }

    }
}
