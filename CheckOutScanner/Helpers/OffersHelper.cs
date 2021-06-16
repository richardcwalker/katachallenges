using CheckOutScanner.Models;
using CheckOutScanner.Services.Offers;
using System.Collections.Generic;

namespace CheckOutScanner.Helpers
{
    /// <summary>
    /// Gets offers data
    /// </summary>
    public class OffersHelper : HelpersBase
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
