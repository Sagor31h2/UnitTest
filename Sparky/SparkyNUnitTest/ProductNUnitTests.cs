using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class ProductNUnitTests
    {   //Normal test
        [Test]
        public void GetPrice_PlatinumCustomer_returnWith20PercentDiscount()
        {
            var product = new Product();
            product.Price = 50;
            var result = product.GetPrice(new Customer() { IsPlatinum = true });

            Assert.That(result, Is.EqualTo(40));
        }

        //Mock abuse
        [Test]
        public void GetPriceMockAbuse_PlatinumCustomer_returnWith20PercentDiscount()
        {
            var customer = new Mock<ICustomer>();
            customer.Setup(u => u.IsPlatinum).Returns(true);
            var product = new Product();
            product.Price = 50;
            var result = product.GetPrice(customer.Object);

            Assert.That(result, Is.EqualTo(40));
        }


    }
}