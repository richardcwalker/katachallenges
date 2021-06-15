using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutScanner.Models
{
    public class ModelsBase
    {
        public string SKUBeingScanned { get; set; }
        public Guid TransactionId;
    }
}
