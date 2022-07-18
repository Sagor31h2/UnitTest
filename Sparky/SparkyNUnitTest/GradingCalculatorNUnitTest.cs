using NUnit.Framework;
namespace Sparky
{
    public class GradingCalculatorNUnitTest
    {
        private GradingCalculator _gradingCalculator;

        [SetUp]
        public void SetUp()
        {
            _gradingCalculator = new GradingCalculator();
        }

        //score 95 attendence 90 
        [Test]
        public void GradingCalculator_Score95Attendence90_GetA()
        {
            _gradingCalculator.Score = 95;
            _gradingCalculator.AttendencePercentence = 90;
            var result = _gradingCalculator.GetGrade();

            Assert.That(result, Is.EqualTo("A"));
        }

        //score 85 attendence 90 
        [Test]
        public void GradingCalculator_Score85Attendence90_Getb()
        {
            _gradingCalculator.Score = 85;
            _gradingCalculator.AttendencePercentence = 90;
            var result = _gradingCalculator.GetGrade();

            Assert.That(result, Is.EqualTo("B"));
        }

        //score 65 attendence 90 
        [Test]
        public void GradingCalculator_Score65Attendence90_Getc()
        {
            _gradingCalculator.Score = 65;
            _gradingCalculator.AttendencePercentence = 90;
            var result = _gradingCalculator.GetGrade();

            Assert.That(result, Is.EqualTo("C"));
        }

        //score 95 attendence 65 
        [Test]
        public void GradingCalculator_Score95Attendence65_GetB()
        {
            _gradingCalculator.Score = 95;
            _gradingCalculator.AttendencePercentence = 65;
            var result = _gradingCalculator.GetGrade();

            Assert.AreEqual(result, "B");
        }

        //Failed tests
        [Test]
        [TestCase(95, 55)]
        [TestCase(65, 55)]
        [TestCase(55, 90)]
        public void GradingCalculator_ScoreAndAttendenceToFail_GetF(int score, int attendence)
        {
            _gradingCalculator.Score = score;
            _gradingCalculator.AttendencePercentence = attendence;
            var result = _gradingCalculator.GetGrade();
            Assert.AreEqual(result, "F");
        }

        //Pass multiple value and check result
        [Test]
        [TestCase(95, 90, ExpectedResult = "A")]
        [TestCase(85, 90, ExpectedResult = "B")]
        [TestCase(65, 90, ExpectedResult = "C")]
        [TestCase(95, 65, ExpectedResult = "B")]
        [TestCase(95, 55, ExpectedResult = "F")]
        [TestCase(65, 55, ExpectedResult = "F")]
        [TestCase(55, 90, ExpectedResult = "F")]
        public string GradingCalculator_PassMultipleResult_GetReturnValue(int score, int attendence)
        {
            _gradingCalculator.Score = score;
            _gradingCalculator.AttendencePercentence = attendence;
            return _gradingCalculator.GetGrade();
        }
    }
}