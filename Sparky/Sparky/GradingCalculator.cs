namespace Sparky
{
    public class GradingCalculator
    {
        public int Score { get; set; }
        public int AttendencePercentence { get; set; }

        public string GetGrade()
        {
            if (Score > 90 && AttendencePercentence > 70)
            {
                return "A";
            }
            else if (Score > 80 && AttendencePercentence > 60)
            {
                return "B";
            }
            else if (Score > 60 && AttendencePercentence > 60)
            {
                return "C";
            }
            else
            {
                return "F";
            }
        }
    }
}