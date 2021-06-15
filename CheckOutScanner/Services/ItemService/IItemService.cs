using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutScanner.Services
{
    public interface IItemService
    {
        public bool AddScannedItem(Guid TransactionID, string SKUBeingScanned);
        public Decimal GetTotalPriceOfItems(string transactionID);

    }
}
