using CheckOutScanner.DataAccessLayer;
using CheckOutScanner.Services.Offers;
using CheckOutScanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckOutScanner.Services.ItemService
{
    public class ItemService : ServicesBase, IItemService
    {
        private List<Item> ItemCostPriceList;
        private ItemScannerDAL _itemScannerDAL;
        private OffersService _offersService;
        private int numberOfOffersApplied = 0;
        private int remainder;
        private decimal runningTotal;
        private decimal offerPriceTotal;
        private decimal singleUnitPriceTotal;
        private string SKU;
        private int offersCountForThisSKU;
        public ItemService()
        {
            _itemScannerDAL = new ItemScannerDAL();
            _offersService = new OffersService();
            ItemCostPriceList = _itemScannerDAL.BuildItemCostPriceList();
        }

        /// <summary>
        /// Add the scanned item to our array of items
        /// </summary>
        /// <param name="SKUBeingScanned"></param>
        /// <returns></returns>
        public bool AddScannedItem(Guid TransactionID, string SKUBeingScanned)
        {
            if (!string.IsNullOrEmpty(SKUBeingScanned))
            {
                //Is this a valid SKU
                try
                {
                    if (ItemCostPriceList.Any(cus => cus.SKU == SKUBeingScanned))
                    {
                        SaveScannedItem(TransactionID, ItemCostPriceList.First(i => i.SKU == SKUBeingScanned));
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
        /// <param name="transactionID"></param>
        /// <returns></returns>
        public Decimal GetTotalPriceOfItems(Guid transactionID)
        {
            //Get items and sort by SKU
            List<Item> allScannedItems = new List<Item>();
            allScannedItems = _itemScannerDAL.GetAllScannedItems(transactionID);
            //Get Offers
            IDictionary<string, Offer> offerCostTable = _offersService.GetOffersPriceTable();
            return GetTotalPriceForSKUs(allScannedItems);

        }

        /// <summary>
        /// Calc the total price
        /// </summary>
        /// <param name="allScannedItems"></param>
        /// <returns></returns>
        private decimal GetTotalPriceForSKUs(List<Item> allScannedItems)
        {
            foreach (var item in from item in allScannedItems
                                 select item)
            {
                //Get any offers and store the totals for these

                GetAnyOffers(allScannedItems, item);

                runningTotal = runningTotal + singleUnitPriceTotal + offerPriceTotal;
                singleUnitPriceTotal = 0;
                offerPriceTotal = 0;

            }
            return runningTotal;
        }

        /// <summary>
        /// Count SKUs in List and see if these have offers (quantity from offers table)
        /// </summary>
        /// <param name="allScannedItems"></param>
        /// <param name="offerCostTable"></param>
        /// <param name="item"></param>
        private void GetAnyOffers(List<Item> allScannedItems, Item item)
        {
            IDictionary<string, Offer> offerCostTable = _offersService.GetOffersPriceTable();
            //Check the SKU is on the offers table before doing anything
            if (offerCostTable.ContainsKey(item.SKU))
            {
                if (SKU != item.SKU)
                {
                    foreach ((KeyValuePair<string, Offer> offer, int offersCountForThisSKU) in
                                  from offer in offerCostTable
                                  select (offer, offersCountForThisSKU))
                    {
                        if (offer.Value.SKU == item.SKU)
                        {
                            {
                                numberOfOffersApplied = Math.DivRem(allScannedItems.Count(c => c.SKU == offer.Key), offer.Value.Quantity, out remainder);
                                //Get offer total
                                offerPriceTotal = numberOfOffersApplied * offer.Value.OfferPrice;
                                //Any remaining items charged at normal price
                                if (remainder > 0)
                                {
                                    //Get SKU cost price to add the remaining non-offered item
                                    singleUnitPriceTotal = remainder * item.UnitPrice;
                                }
                            }

                        }

                    }
                }
            }
            else
            {
                //Item SKU not on offer so just add the UnitPrice
                singleUnitPriceTotal = singleUnitPriceTotal + item.UnitPrice;
            }
            SKU = item.SKU;
        }


        /// <summary>
        /// Get and save the scannd item
        /// Adds scanned item to our ongoing list of scanned items
        /// </summary>
        /// <param name="scannedItem"></param>
        /// <returns></returns>
        private void SaveScannedItem(Guid transactionID, Item scannedItem)
        {
            _itemScannerDAL.AddItemScanned(transactionID, scannedItem);
        }
    }
}
