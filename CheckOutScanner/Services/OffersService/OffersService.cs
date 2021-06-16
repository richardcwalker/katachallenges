using CheckOutScanner.DataAccessLayer;
using CheckOutScanner.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutScanner.Services.Offers
{
    public class OffersService : ServicesBase, IOffersService
    {
        private ItemScannerDAL _itemScannerDAL;
        public OffersService()
        {
            _itemScannerDAL = new ItemScannerDAL();
        }
        /// <summary>
        /// Get the offers table for our totals calcs
        /// </summary>
        /// <returns>A table of prices (SKU, quantity to use for offer and cost)</returns>
        public IDictionary<string, Offer> GetOffersPriceTable()
        {
           return _itemScannerDAL.BuildOffersPriceTable();
        }

    }
}
