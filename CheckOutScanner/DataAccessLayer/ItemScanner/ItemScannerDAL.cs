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

        /// <summary>
        /// Add scanned items to list
        /// </summary>
        /// <param name="itemScanned"></param>
        /// <returns></returns>
        public List<Item> AddItemScanned(Guid TransactionID, Item itemScanned)
        {
            //Set the Item TransactionID
            itemScanned.TransactionId = TransactionID;
            ListOfScannedItems.Add(itemScanned);
            return ListOfScannedItems;
        }

        /// <summary>
        /// Get the pricing list
        /// </summary>
        /// <returns></returns>
        public List<Item> BuildItemCostPriceList()
        {
            ItemCostPriceList.Add(new Item { ProductName = "Apples", SKU = "A99", UnitPrice = 0.5M });
            ItemCostPriceList.Add(new Item { ProductName = "Biscuits", SKU = "B15", UnitPrice = 0.3M });
            ItemCostPriceList.Add(new Item { ProductName = "Carrots", SKU = "C40", UnitPrice = 0.6M });

            return ItemCostPriceList;
        }

        
    }
}
