using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class CustomerNUnitTest
    {
        //global cons
        private Customer _customer;

        [SetUp]
        public void Setup()
        {
            _customer = new Customer();
        }

        [Test]
        [TestCase("Kamrul", "Hassan")]
        public void Input_firstNameAndLastname_getGreetings(string firstName, string lastName)
        {

            var greet = _customer.GreetByName(firstName, lastName);

            Assert.That(greet, Is.EqualTo("Hello Kamrul Hassan"));
            Assert.That(greet, Does.Contain("Hello").IgnoreCase);

        }

        //Input nothing and get null value

        [Test]
        public void InputNOthing_GetNull()
        {

            Assert.IsNull(_customer.Greet);
        }
    }
}
