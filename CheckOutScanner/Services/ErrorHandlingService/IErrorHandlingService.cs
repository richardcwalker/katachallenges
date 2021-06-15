using CheckOutScanner.Models;

namespace CheckOutScanner.Services.ErrorHandlingService
{
    public interface IErrorHandlingService
    {
        public void LogError(Error error);
    }
}