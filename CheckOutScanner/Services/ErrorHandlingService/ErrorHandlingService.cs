using CheckOutScanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutScanner.Services.ErrorHandlingService
{
    public class ErrorHandlingService : IErrorHandlingService
    {
        public ErrorHandlingService()
        {

        }

        /// <summary>
        /// Log our error message
        /// </summary>
        /// <param name="error"></param>
        public void LogError(Error error)
        {
            //TODO Log to some error DB

        }
    }
}
