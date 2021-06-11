using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutScanner.Models
{
    public class Offer
    {
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public string OfferPrice { get; set; }

        public Offer()
        {

        }
    }
}
