using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class CustomerNUnitTest
    {
        [Test]
        [TestCase("Kamrul", "Hassan")]
        public void Input_firstNameAndLastname_getGreetings(string firstName, string lastName)
        {
            var customer = new Customer();

            var greet = customer.GreetByName(firstName, lastName);

            Assert.That(greet, Is.EqualTo("Hello Kamrul Hassan"));
            Assert.That(greet, Does.Contain("Hello").IgnoreCase);

        }
    }
}
