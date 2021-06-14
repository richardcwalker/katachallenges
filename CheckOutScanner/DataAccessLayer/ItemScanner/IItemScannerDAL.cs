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
        public List<Item> AddItemScanned(Item itemScanned);
        public IDictionary<string, decimal> BuildItemCostPriceTable();
    }
}
