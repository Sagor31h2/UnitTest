using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class BankAccountNUnitTests
    {
        private BankAccount Account;
        [SetUp]
        public void SetUp()
        {
        }

        //deposite 100
        [Test]
        public void BankDepositeLogFaker_Add100_ReturnTrue()
        {
            var _bankAccount = new BankAccount(new LogBook());
            var result = _bankAccount.Deposit(100);
            Assert.IsTrue(result);
            Assert.AreEqual(_bankAccount.Getbalance(), 100);
        }

        [Test]
        public void BankDeposite_Add100_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            var _bankAccount = new BankAccount(logMock.Object);
            var result = _bankAccount.Deposit(100);
            Assert.IsTrue(result);
            Assert.AreEqual(_bankAccount.Getbalance(), 100);
        }
    }
}