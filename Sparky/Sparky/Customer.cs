namespace Sparky
{
    public class Customer
    {
        public string? Greet { get; set; }
        public int OrderTotal { get; set; }
        public string GreetByName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("Empty or contains white space in first name");
            }
            Greet = "Hello " + firstName + " " + lastName;
            return Greet;
        }
        public CustomerType GetCustomerByDetails()
        {
            if (OrderTotal < 100)
            {
                return new BasicCustomer();
            }
            else
            {
                return new PlatinumCustomer();
            }
        }
    }
    public class CustomerType { }
    public class BasicCustomer : CustomerType { }
    public class PlatinumCustomer : CustomerType { }
}
