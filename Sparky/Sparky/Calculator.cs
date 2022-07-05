namespace Sparky
{
    public class Calculator
    {
        public List<int> NumberRange = new List<int>();
        //Adding two numbers
        public int AddNumbers(int a, int b)
        {
            return a + b;
        }

        //Cheaking isOdd
        public bool IsOdd(int a)
        {
            return (a % 2 != 0);
        }

        //Adding two double Numbers

        public double AddTwoDoubles(double a, double b)
        {
            return a + b;
        }

        //Get odd range
        public List<int> GetOddRange(int min, int max)
        {
            NumberRange.Clear();

            for (int i = min; i <= max; i++)
            {
                if (i % 2 != 0)
                {
                    NumberRange.Add(i);
                }
            }
            return NumberRange;
        }
    }


}