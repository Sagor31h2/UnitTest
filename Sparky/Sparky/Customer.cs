namespace Sparky
{
    public class Customer
    {
        public string? Greet { get; set; }
        public string GreetByName(string firstName, string lastName)
        {
            Greet = "Hello " + firstName + " " + lastName;
            return Greet;
        }
    }
}
