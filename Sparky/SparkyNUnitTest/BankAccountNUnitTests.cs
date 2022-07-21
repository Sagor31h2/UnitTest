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

        //Moq for false condition
        [TestCase(200, 300)]
        public void BankWithdraw_Withdraw300With200Balance_ReturnsFalse(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();

            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);
            //logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x < 0))).Returns(false);
            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);

            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(balance);
            var result = bankAccount.Withdraw(withdraw);
            Assert.IsFalse(result);
        }

        //moq return
        [Test]
        public void BankLog_LogString_ReturnString()
        {
            var logMock = new Mock<ILogBook>();

            logMock.Setup(u => u.LogReturnString(It.IsAny<string>())).Returns((string str) => str);

            Assert.That(logMock.Object.LogReturnString("hello"), Is.EqualTo("hello"));

        }
    }
}