using CheckOutScanner.Helpers;
using CheckOutScanner.Models;
using CheckOutScanner.Services.ItemService;
using System;

namespace CheckOutScanner.BusinessLogic
{
    /// <summary>
    /// Class used by teh actual scanner software
    /// </summary>
    public class Checkout : BusinessLogicBase
    {
        private ItemHelper itemHelper;
        public Checkout()
        {
            itemHelper = new ItemHelper();
        }

        /// <summary>
        /// Scanner would pass each item SKU and a transaction ID and return true to the UI if Ok else false.
        /// </summary>
        /// <param name="TransactionId">Transaction ID from the scanner</param>
        /// <param name="SKUBeingScanned">Product SKU being scanned</param>
        public bool ScanItem(Guid TransactionId, string SKUBeingScanned)
        {
            return itemHelper.AddItem(TransactionId, SKUBeingScanned);
        }

        /// <summary>
        /// Pass in transaction ID and get totals for this transaction
        /// </summary>
        /// <param name="transactionID">Transaction ID from the scanner</param>
        /// <returns></returns>
        public Decimal GetTotalPriceOfItems(Guid transactionID)
        {
            return itemHelper.GetTotalPriceOfItems(transactionID);
        }

    }
}
