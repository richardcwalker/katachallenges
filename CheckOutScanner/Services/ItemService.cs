using CheckOutScanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutScanner.Services
{
    public class ItemService : ServicesBase
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

        public bool AddItem(Item item)
        {
            //Get the latest cost prices

            
            if (item != null)
            {
                //Is this a valid SKU
                try
                {
                    if (ItemCostPriceTable.ContainsKey(item.SKU))
                    {
                        item.UnitPrice = ItemCostPriceTable[item.SKU];
                        SaveRunningTotal(item);
                        return true;
                    }
                    else
                    {
                        // No key found    
                        // Some error logging with 'Missing SKU' error message
                        return false;

                    }
                        
                    
                }
                catch (Exception)
                {
                    // No key found    
                    // Some error logging with exception details
                    return false;
                }
            }
            else
            {
                // Some error logging with 'No item passed to scan' error
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

        private RunningTotal SaveRunningTotal(Item scannedItem)
        {
            return null;
        }
    }
}
