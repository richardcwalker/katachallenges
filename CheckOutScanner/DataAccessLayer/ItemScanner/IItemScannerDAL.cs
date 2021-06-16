using CheckOutScanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutScanner.DataAccessLayer.ItemScanner
{
    public interface IItemScannerDAL
    {
        public List<Item> SaveScannedItem(Guid TransactionID, Item itemScanned);
        public List<Item> GetAllScannedItems(Guid transactionID);
        public List<Item> BuildItemCostPriceTable();
        public IDictionary<string, Offer> BuildOffersPriceTable();
    }
}
