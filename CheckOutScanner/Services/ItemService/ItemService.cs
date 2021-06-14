using CheckOutScanner.DataAccessLayer;
using CheckOutScanner.Models;
using CheckOutScanner.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutScanner.Services
{
    public class ItemService : ServicesBase, IService, IItemService
    {
        private IDictionary<string, decimal> ItemCostPriceTable;
        private List<Item> ItemCostPriceList;
        private ItemScannerDAL _itemScannerDAL;

        public ItemService()
        {
            _itemScannerDAL = new ItemScannerDAL();
            ItemCostPriceTable = _itemScannerDAL.BuildItemCostPriceTable();
            ItemCostPriceList = _itemScannerDAL.BuildItemCostPriceList();
        }

        /// <summary>
        /// Add the scanned item to our array of items
        /// </summary>
        /// <param name="SKUBeingScanned"></param>
        /// <returns></returns>
        public bool AddScannedItem(string SKUBeingScanned)
        {
            if (!string.IsNullOrEmpty(SKUBeingScanned))
            {
                //Is this a valid SKU
                try
                {
                    if (ItemCostPriceTable.ContainsKey(SKUBeingScanned))
                    {
                        Item item = new()
                        {
                            UnitPrice = ItemCostPriceTable[SKUBeingScanned]
                        };
                        SaveScannedItem(item);
                        return true;
                    }
                    else
                    {
                        // No key found    
                        HandleServiceError(001, SKU_NOTFOUND_MESSAGE_001, SKUBeingScanned);
                        return false;
                    }


                }
                catch (Exception e)
                {
                    // Unhandled exception error logging with exception details
                    HandleServiceError(999, SYSTEM_EXCEPTION_999 + "--->" + e.Message, SKUBeingScanned);
                    return false;
                }
            }
            else
            {
                // Some error logging with 'Missing SKU' error message
                HandleServiceError(001, SKU_NOTSUPPLIED_MESSAGE_002, SKUBeingScanned);
                return false;
            }
        }

        /// <summary>
        /// Request a total applying discounts
        /// </summary>
        /// <param name="arrayOfScannedItems"></param>
        /// <returns></returns>
        public Decimal GetTotalPriceOfItems(string transactionID)
        {
            return 0M;
        }

        /// <summary>
        /// Get and save the scannd item
        /// Adds scanned item to our ongoing list of scanned items
        /// </summary>
        /// <param name="scannedItem"></param>
        /// <returns></returns>
        private void SaveScannedItem(Item scannedItem)
        {
            _itemScannerDAL.AddItemScanned(scannedItem);

            // AddItemScanned(scannedItem);
        }
    }
}
