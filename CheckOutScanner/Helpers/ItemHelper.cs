using CheckOutScanner.Models;
using CheckOutScanner.Services.ErrorHandlingService;
using CheckOutScanner.Services.ItemService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutScanner.Helpers
{
    /// <summary>
    /// Helper for scanner business logic layer 
    /// </summary>
    public class ItemHelper : HelpersBase
    {
        private ItemService _itemService;
        public ItemHelper()
        {
            _itemService = new ItemService();
        }

        /// <summary>
        /// Add item via service layer
        /// </summary>
        /// <param name="TransactionID"></param>
        /// <param name="SKUBeingScanned"></param>
        /// <returns></returns>
        public bool AddItem(Guid TransactionID, string SKUBeingScanned)
        {
            if (TransactionID == null)
            {
                HandleServiceError(001, TRANSID_NOTSUPPLIED_MESSAGE_003, SKUBeingScanned);
                return false;
            }
            if (!string.IsNullOrEmpty(SKUBeingScanned))
            {
                return _itemService.AddScannedItem(TransactionID, SKUBeingScanned);
            }
            else
            {
                HandleServiceError(002, SKU_NOTSUPPLIED_MESSAGE_002, SKUBeingScanned);
                return false;
            }
        }

        /// <summary>
        /// Get total via service layer
        /// </summary>
        /// <param name="TransactionID"></param>
        /// <returns></returns>
        public Decimal GetTotalPriceOfItems(Guid TransactionID)
        {
            if (TransactionID == null)
            {
                HandleServiceError(001, TRANSID_NOTSUPPLIED_MESSAGE_003, "");
                return 0;
            }

            return _itemService.GetTotalPriceOfItems(TransactionID);
        }
    }
}
