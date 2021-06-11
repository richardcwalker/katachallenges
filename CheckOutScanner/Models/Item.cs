using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutScanner.Models
{
    public class Item : ModelsBase
    {
        public string SKU { get; set; }
        public decimal UnitPrice { get; set; }
        public string ProductName { get; set; }
    }
}
