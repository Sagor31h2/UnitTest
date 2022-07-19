using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class BankAccountNUnitTests
    {
        private BankAccount _bankAccount;
        [SetUp]
        public void SetUp()
        {
            _bankAccount = new BankAccount(new LogBook());
        }

        //deposite 100
        [Test]
        public void BankDeposite_Add100_ReturnTrue()
        {
            var result = _bankAccount.Deposit(100);
            Assert.IsTrue(result);
            Assert.AreEqual(_bankAccount.Getbalance(), 100);
        }
    }
}