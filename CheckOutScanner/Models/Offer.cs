﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutScanner.Models
{
    public class Offer : ModelsBase
    {
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public Decimal OfferPrice { get; set; }

        public Offer()
        {

        }
    }
}
