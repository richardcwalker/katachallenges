using CheckOutScanner.Models;
using CheckOutScanner.Services.ErrorHandlingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutScanner.Services
{
    public class ServicesBase
    {
        protected const string SKU_NOTFOUND_MESSAGE_001 = "SKU Not Found";
        protected const string SKU_NOTSUPPLIED_MESSAGE_002 = "SKU not supplied by scanner";
        protected const string SYSTEM_EXCEPTION_999 = "System Exception Thrown";
        

        protected void HandleServiceError(int ErrorCode, string ErrorMessage, string SKUBeingScanned)
        {
            Error error = new()
            {
                ErrorCode = ErrorCode,
                ErrorMessage = ErrorMessage,
                SKUBeingScanned = SKUBeingScanned
            };
            LogError(error);
        }

        //
        /// <summary>
        /// Call the error handling service
        /// </summary>
        /// <param name="error"></param>
        private void LogError(Error error)
        {
            ErrorHandlingService.ErrorHandlingService errorHandler = new();
            errorHandler.LogError(error);
        }
    }
}
