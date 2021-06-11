using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutScanner.Models
{
    public class Error : ModelsBase
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
