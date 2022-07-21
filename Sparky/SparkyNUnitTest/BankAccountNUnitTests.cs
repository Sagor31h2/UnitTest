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
        // [Test]
        // public void BankDepositeLogFaker_Add100_ReturnTrue()
        // {
        //     var _bankAccount = new BankAccount(new LogBook());
        //     var result = _bankAccount.Deposit(100);
        //     Assert.IsTrue(result);
        //     Assert.AreEqual(_bankAccount.Getbalance(), 100);
        // }

        [Test]
        public void BankDeposite_Add100_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            var _bankAccount = new BankAccount(logMock.Object);
            var result = _bankAccount.Deposit(100);
            Assert.IsTrue(result);
            Assert.AreEqual(_bankAccount.Getbalance(), 100);
        }

        //Moq with condition
        [Test]
        [TestCase(300, 200)]
        [TestCase(400, 300)]
        public void BankAccount_DepositeAndWithdraw_ReturnTrue(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);

            var _bankAccount = new BankAccount(logMock.Object);
            _bankAccount.Deposit(balance);
            var result = _bankAccount.Withdraw(withdraw);

            Assert.IsTrue(result);
        }
    }
}