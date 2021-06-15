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

        public void LogError(Error error)
        {
            //Log to some error DB

        }
    }
}
