using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutScanner.Services
{
    public class ItemService
    {
        public ItemService()
        {

        }

        /// <summary>
        /// Get the price table for our items
        /// </summary>
        /// <returns>A table of prices (SKU and cost)</returns>
        public IDictionary <string, decimal> GetItemCostPriceTable()
        {
            Dictionary<string, decimal> SKUPriceTable = new Dictionary<string, decimal>();
            //TODO - Refactor to get from DAL / DB
            SKUPriceTable.Add("A99", 0.50M);
            SKUPriceTable.Add("B15", 0.30M);
            SKUPriceTable.Add("C40", 0.60M);

            return SKUPriceTable;
        }
    }
}
