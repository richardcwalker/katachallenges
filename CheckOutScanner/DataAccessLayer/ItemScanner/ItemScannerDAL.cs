using CheckOutScanner.DataAccessLayer.ItemScanner;
using CheckOutScanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutScanner.DataAccessLayer
{
    public class ItemScannerDAL : IItemScannerDAL
    {
        private List<Item> ListOfScannedItems { get; set; }
        private List<Item> ItemCostPriceList { get; set; }
        public ItemScannerDAL()
        {
            ListOfScannedItems = new();
            ItemCostPriceList = new();
        }

        public List<Item> AddItemScanned(Item itemScanned)
        {
            ListOfScannedItems.Add(itemScanned);
            return ListOfScannedItems;
        }

        public IDictionary<string, decimal> BuildItemCostPriceTable()
        {
            Dictionary<string, decimal> ItemPriceTable = new()
            {
                { "A99", 0.50M },
                { "B15", 0.30M },
                { "C40", 0.60M }
            };

            return ItemPriceTable;
        }

        public List<Item> BuildItemCostPriceList()
        {
            ItemCostPriceList.Add(new Item { ProductName = "Apples", SKU = "A99", UnitPrice = 0.5M });
            ItemCostPriceList.Add(new Item { ProductName = "Biscuits", SKU = "B15", UnitPrice = 0.3M });
            ItemCostPriceList.Add(new Item { ProductName = "Carrots", SKU = "C40", UnitPrice = 0.6M });

            return ItemCostPriceList;
        }

        
    }
}
