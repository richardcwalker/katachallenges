using CheckOutScanner.Models;
using CheckOutScanner.Services;
using CheckOutScanner.Services.ErrorHandlingService;
using Moq;
using NUnit.Framework;


namespace CheckOutScannerTests.ServicesTests
{
    [TestFixture]
    public class ErrorHandlingServiceTests : TestBase
    {
        [Test]
        public void ErrorHandlingServiceConstructorTest()
        {
            ErrorHandlingService errorHandlingService = new ErrorHandlingService();
            Assert.IsNotNull(errorHandlingService);
        }

        [Test]
        public void LogError()
        {
            ErrorHandlingService errorHandlingService = new ErrorHandlingService();
            Error error = new()
            {
                ErrorCode = 001,
                ErrorMessage = "Error logged from test",
                SKUBeingScanned = "SKU001"
            };
            //TODO ERROR LOGGING?!?!?!
            errorHandlingService.LogError(error);
        }
    }
}
