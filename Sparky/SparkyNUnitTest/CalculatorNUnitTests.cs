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

        [Test]
        public void IsOdd_InputOddNumber_GetTrue()
        {
            var calculator = new Calculator();

            var result = calculator.IsOdd(5);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsOdd_InputEvenNumber_GetFalse()
        {
            var calculator = new Calculator();

            var result = calculator.IsOdd(6);

            Assert.That(result, Is.EqualTo(false));
        }

        //passing multiple value
        [Test]
        [TestCase(2)]
        [TestCase(12)]
        [TestCase(114)]
        [TestCase(126)]

        public void IsOdd_InputMultiplaEvenNumber_GetFalse(int a)
        {
            var calculator = new Calculator();

            var result = calculator.IsOdd(a);

            Assert.That(result, Is.EqualTo(false));
        }

        //combine with expected result
        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(11, ExpectedResult = true)]
        public bool Isodd_inputNumer_GetResult(int a)
        {
            var calculator = new Calculator();
            return calculator.IsOdd(a);
        }

        //Add two double values
        [Test]
        [TestCase(12.1, 2.4)]
        public void AddDouble_InputTwoDoubleNumbers_GetCorrectAddition(double a, double b)
        {   //Arrange
            var calculator = new Calculator();

            //Act
            double result = calculator.AddTwoDoubles(a, b);

            //Assert
            Assert.AreEqual(14.5, result);
        }

    }
}