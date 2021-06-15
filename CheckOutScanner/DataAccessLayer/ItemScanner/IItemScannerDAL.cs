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
        public List<Item> AddItemScanned(Guid TransactionID, Item itemScanned);
    }
}
