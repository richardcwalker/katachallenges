using CheckOutScanner.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutScanner.Services.OffersService
{
    public class OffersService : ServicesBase, IOffersService
    {
        public OffersService()
        {

        }
        /// <summary>
        /// Get the offers table for our totals calcs
        /// </summary>
        /// <returns>A table of prices (SKU, quantity to use for offer and cost)</returns>
        public IDictionary<string, Offer> GetOffersPriceTable()
        {
           return BuildOffersPriceTable();
        }

        /// <summary>
        /// Load the offers table for our totals calcs
        /// </summary>
        /// <returns>A table of prices (SKU, quantity to use for offer and cost)</returns>
        private IDictionary<string, Offer> BuildOffersPriceTable()
        {
            Dictionary<string, Offer> OfferPriceTable = new Dictionary<string, Offer>();
            //TODO Refactor into DAL
            OfferPriceTable.Add("A99", new Offer { SKU = "A99", Quantity = 3, OfferPrice = 1.30M });
            OfferPriceTable.Add("B15", new Offer { SKU = "B15", Quantity = 2, OfferPrice = 0.45M });

            return OfferPriceTable;
        }

        

    }
}
