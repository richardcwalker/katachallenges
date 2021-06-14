using CheckOutScanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutScanner.Services
{
    public class ItemService : ServicesBase, IService
    {
        private IDictionary<string, decimal> ItemCostPriceTable;

        public ItemService()
        {
            ItemCostPriceTable = BuildItemCostPriceTable();
        }

        /// <summary>
        /// Get the price table for our items
        /// </summary>
        /// <returns>A table of prices (SKU and cost)</returns>
        public IDictionary <string, decimal> GetItemCostPriceTable()
        {
            return BuildItemCostPriceTable();
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
                        Item item = new Item
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
        /// Load price table for our items
        /// </summary>
        /// <returns>A table of prices (SKU and cost)</returns>
        private IDictionary<string, decimal> BuildItemCostPriceTable()
        {
            Dictionary<string, decimal> ItemPriceTable = new Dictionary<string, decimal>();
            //TODO Refactor into DAL
            ItemPriceTable.Add("A99", 0.50M);
            ItemPriceTable.Add("B15", 0.30M);
            ItemPriceTable.Add("C40", 0.60M);

            return ItemPriceTable;
        }

        /// <summary>
        /// Get and save the scannd item
        /// </summary>
        /// <param name="scannedItem"></param>
        /// <returns></returns>
        private RunningTotal SaveScannedItem(Item scannedItem)
        {
            return null;
        }

        /// <summary>
        /// Request a total
        /// </summary>
        /// <param name="arrayOfScannedItems"></param>
        /// <returns></returns>
        private void GetTotalPrice(string arrayOfScannedItems)
        {
        }

    }
}
