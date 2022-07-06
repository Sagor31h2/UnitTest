namespace Sparky
{
    public class Customer
    {
        public string? Greet { get; set; }
        public string GreetByName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("Empty or contains white space in first name");
            }
            Greet = "Hello " + firstName + " " + lastName;
            return Greet;
        }
    }
}
