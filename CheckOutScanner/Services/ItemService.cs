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
            Dictionary<string, decimal> ItemPriceTable = new Dictionary<string, decimal>();
            //TODO Refactor into DAL
            ItemPriceTable.Add("A99", 0.50M);
            ItemPriceTable.Add("B15", 0.30M);
            ItemPriceTable.Add("C40", 0.60M);

            return ItemPriceTable;
        }
    }
}
