using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutScanner.Services.CheckOutService
{
    public class CheckOutService: ServicesBase, ICheckOutService
    {
        public CheckOutService()
        {

        }

        public bool ScanItem()
        {
            return true;

        }
    }
}
