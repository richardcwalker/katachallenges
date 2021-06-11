using CheckOutScanner.Models;
using CheckOutScanner.Services;
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

        public bool AddItem(Item item)
        {
            if (item != null)
            {
                return _itemService.AddItem(item);
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
