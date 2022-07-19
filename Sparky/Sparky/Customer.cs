namespace Sparky
{
    public interface ICustomer
    {
        int Discount { get; set; }
        string? Greet { get; set; }
        int OrderTotal { get; set; }
        bool IsPlatinum { get; set; }
        string GreetByName(string firstName, string lastName);
        CustomerType GetCustomerByDetails();

    }
    public class Customer : ICustomer
    {
        public int Discount { get; set; }
        public string? Greet { get; set; }
        public int OrderTotal { get; set; }
        public bool IsPlatinum { get; set; }
        public Customer()
        {
            Discount = 15;
            IsPlatinum = false;
        }
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
