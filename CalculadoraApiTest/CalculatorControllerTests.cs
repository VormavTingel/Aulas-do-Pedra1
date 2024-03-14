using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculadoraAPI.Controllers;

namespace CalculadoraApiTest
{
    [TestClass]
    public class CalculatorControllerTests
    {
        [TestMethod]
        public void TestGet()
        {
            // Arrange
            CalculatorController calculatorController = new CalculatorController();

            // Act
            var result = calculatorController.Get();

            // Assert
            Assert.IsNotNull(result);
            // Add more assertions as needed
        }

        [TestMethod]
        public void TestPost()
        {
            // Arrange
            CalculatorController calculatorController = new CalculatorController();
            var request = new CalculatorController.MemoryRequestResponse();
            request.M1 = 1;
            request.M2 = 2;
            request.M3 = 3;

            // Act
            var result = calculatorController.Post(request);

            // Assert
            Assert.IsNotNull(result);
            // Add more assertions as needed
        }

        [TestMethod]
        public async void TestE2E()
        {
            // Arrange
            CalculatorController calculatorController = new CalculatorController();
            var request = new CalculatorController.MemoryRequestResponse();
            request.M1 = 1;
            request.M2 = 2;
            request.M3 = 3;

            // Act
            var postResult = calculatorController.Post(request);
            var getResult = calculatorController.Get();
            var getResultPayload = await getResult.ExecuteResultAsync();

            // Assert
            Assert.IsNotNull(postResult);
            Assert.IsNotNull(getResult);
            Assert.AreEqual(1, getResult.M1);
            // Add more assertions as needed
        }
    }
}
