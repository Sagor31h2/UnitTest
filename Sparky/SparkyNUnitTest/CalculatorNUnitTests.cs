using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        [Test]
        public void AddNumbers_InputTwoNumbers_GetCorrectAddition()
        {   //Arrange
            var calculator = new Calculator();

            //Act
            int result = calculator.AddNumbers(5, 6);

            //Assert
            Assert.AreEqual(11, result);
        }
    }
}