
namespace ConsoleApp1.UnitTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void TestAdd()
        {
            // Arrange
            var calculator = new ConsoleApp1.Calculator();

            // Act
            int result = calculator.Add(5, 3);

            // Assert
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void TestSubstract()
        {
            // Arrange
            var calculator = new ConsoleApp1.Calculator();

            // Act
            int result = calculator.Substract(10, 4);

            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void TestMultiply()
        {
            // Arrange
            var calculator = new ConsoleApp1.Calculator();

            // Act
            int result = calculator.Multiply(6, 3);

            // Assert
            Assert.AreEqual(18, result);
        }

        [TestMethod]
        public void TestDivide()
        {
            // Arrange
            var calculator = new ConsoleApp1.Calculator();

            // Act
            float result = calculator.Divide(8, 2);

            // Assert
            Assert.AreEqual(4.0f, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDivideByZero()
        {
            // Arrange
            var calculator = new ConsoleApp1.Calculator();

            // Act & Assert
            calculator.Divide(10, 0);
        }
    }
}