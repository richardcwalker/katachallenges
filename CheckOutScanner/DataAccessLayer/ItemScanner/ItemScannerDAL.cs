﻿using CheckOutScanner.DataAccessLayer.ItemScanner;
using CheckOutScanner.Models;
using CheckOutScanner.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutScanner.DataAccessLayer
{
    public class ItemScannerDAL : ServicesBase, IItemScannerDAL
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
        public List<Item> SaveScannedItem(Guid TransactionID, Item itemScanned)
        {
            //Set the Item TransactionID
            //TODO Would save to some DB storage here...
            itemScanned.TransactionId = TransactionID;
            ListOfScannedItems.Add(itemScanned);
            return ListOfScannedItems;
        }

        /// <summary>
        /// Get list of the scanned items in SKU order
        /// </summary>
        /// <param name="transactionID"></param>
        /// <returns></returns>

        public List<Item> GetAllScannedItems(Guid transactionID)
        {
            IEnumerable<Item> itemsAddedForTrans = ListOfScannedItems.Where(s => s.TransactionId == transactionID).OrderBy(s => s.SKU);
            return (new List<Item>(itemsAddedForTrans));
        }

        /// <summary>
        /// Get the pricing list
        /// </summary>
        /// <returns></returns>
        public List<Item> BuildItemCostPriceTable()
        {
            //TODO Would abstract to DB here
            ItemCostPriceList.Add(new Item { ProductName = "Apples", SKU = "A99", UnitPrice = 0.5M });
            ItemCostPriceList.Add(new Item { ProductName = "Biscuits", SKU = "B15", UnitPrice = 0.3M });
            ItemCostPriceList.Add(new Item { ProductName = "Carrots", SKU = "C40", UnitPrice = 0.6M });

            return ItemCostPriceList;
        }

        /// <summary>
        /// Load the offers table for our totals calcs
        /// </summary>
        /// <returns>A table of prices (SKU, quantity and price)</returns>
        public IDictionary<string, Offer> BuildOffersPriceTable()
        {
            Dictionary<string, Offer> OfferPriceTable = new Dictionary<string, Offer>();
            //TODO Would abstract to DB here
            OfferPriceTable.Add("A99", new Offer { SKU = "A99", Quantity = 3, OfferPrice = 1.30M });
            OfferPriceTable.Add("B15", new Offer { SKU = "B15", Quantity = 2, OfferPrice = 0.45M });

            return OfferPriceTable;
        }
    }
}
