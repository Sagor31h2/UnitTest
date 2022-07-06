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

            //Multiple assert
            Assert.Multiple(() =>
            {
                Assert.That(greet, Is.EqualTo("Hello Kamrul Hassan"));
                Assert.That(greet, Does.Contain("Hello").IgnoreCase);
            });

        }

        //Input nothing and get null value

        [Test]
        public void InputNOthing_GetNull()
        {

            Assert.IsNull(_customer.Greet);
        }

        //chceking with empty last name
        [Test]
        public void Input_EmptyLastName_GetNotNull()
        {
            _customer.GreetByName("sagor", "");

            var greet = _customer.Greet;

            Assert.Multiple(() =>
            {
                Assert.IsNotNull(greet);
                Assert.IsFalse(string.IsNullOrEmpty(greet));
            });
        }

        //Testing exception
        [Test]
        public void GreetChecker_InputEmptyFirstName_GetThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() => _customer.GreetByName("", "spark"));

            Assert.AreEqual(exception?.Message, "Empty or contains white space in first name");
        }
    }
}
