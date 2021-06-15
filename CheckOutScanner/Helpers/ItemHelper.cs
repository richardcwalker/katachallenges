using CheckOutScanner.Models;
using CheckOutScanner.Services.ItemService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutScanner.Helpers
{
    /// <summary>
    /// Helper for items 
    /// </summary>
    public class ItemHelper : HelpersBase
    {
        private ItemService _itemService;
        public ItemHelper(ItemService itemService)
        {
            _itemService = itemService;
        }

        public bool AddItem(Guid TransactionID, string SKUBeingScanned)
        {
            if (SKUBeingScanned != null)
            {
                return _itemService.AddScannedItem(TransactionID,SKUBeingScanned);
                //Some processing logging..
            }
            else
            {
                //Some error logging..
                return false;
            }
        }
    }
}
