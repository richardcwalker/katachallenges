using CheckOutScanner.Models;
using CheckOutScanner.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutScanner.Helpers
{
    //Load offers into memory
    //Calc offer QuantityAdded / QuantityOfferLimit 
    
    public class OffersHelper
    {
        private OffersService _offersService;
        public OffersHelper(OffersService offersService)
        {
            _offersService = offersService;
        }

        public IDictionary<string, Offer> GetOffersPriceTable()
        {
            return _offersService.GetOffersPriceTable();
        }

    }
}
