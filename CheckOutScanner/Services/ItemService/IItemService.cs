using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutScanner.Services
{
    public interface IItemService
    {
        public bool AddScannedItem(Guid transactionID, string SKUBeingScanned);
        public Decimal GetTotalPriceOfItems(Guid transactionID);

    }
}
