using FluentAssertions;
using Xunit;

namespace Sparky
{
    public class CalculatorXUnitFacts
    {
        private Calculator _calculator;
        public CalculatorXUnitFacts()
        {
            _calculator = new Calculator();
        }

        [Fact]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {

            //Act
            int result = _calculator.AddNumbers(10, 20);


            //Assert
            result.Should().Be(30);
        }

        [Fact]
        public void IsOdd_InputOddNumber_GetTrue()
        {
            var calculator = new Calculator();

            var result = calculator.IsOdd(5);

            result.Should().BeTrue();

        }

        [Fact]
        public void IsOdd_InputEvenNumber_GetFalse()
        {
            var calculator = new Calculator();

            var result = calculator.IsOdd(6);

            result.Should().BeFalse();
        }

        //passing multiple value
        [Theory]
        [InlineData(2)]
        [InlineData(12)]
        [InlineData(114)]
        [InlineData(126)]

        public void IsOdd_InputMultiplaEvenNumber_GetFalse(int a)
        {
            var calculator = new Calculator();

            var result = calculator.IsOdd(a);

            result.Should().BeFalse();
        }

        //combine with expected result
        [Theory]
        [InlineData(10, false)]
        [InlineData(11, true)]
        public void Isodd_inputNumer_GetResult(int a, bool expected)
        {
            var calculator = new Calculator();
            var result = calculator.IsOdd(a);

            result.Should().Be(expected);
        }

        //Add two double values
        [Theory]
        [InlineData(12.1, 2.4)]
        [InlineData(12.1, 2.9)]
        [InlineData(12.1, 1.4)]

        public void AddDouble_InputTwoDoubleNumbers_GetCorrectAddition(double a, double b)
        {   //Arrange
            var calculator = new Calculator();

            //Act
            double result = calculator.AddTwoDoubles(a, b);

            //Assert
            result.Should().BeInRange(10, 20);
        }


        //Number Range
        [Fact]
        public void InputNumber_And_Get_CorrectOddRange()
        {
            var listOfOdd = new List<int>()
            {
                5,7,9
            };

            var result = _calculator.GetOddRange(5, 10);

            result.Should().Equal(listOfOdd);
            result.Should().Contain(7);
        }
    }
}
