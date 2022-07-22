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

        //moq return
        [Test]
        public void BankLog_LogWithReturn_ReturnString()
        {
            var logMock = new Mock<ILogBook>();

            string desireString = "hello";

            logMock.Setup(u => u.LogWithOutput(It.IsAny<string>(), out desireString)).Returns(true);

            var result = "";

            Assert.IsTrue(logMock.Object.LogWithOutput("sagor", out result));
            Assert.AreEqual(result, desireString);
        }

        //testin moq ref
        public void BankLog_LogWithRef_ReturnString()
        {
            var logMock = new Mock<ILogBook>();

            var customer = new Customer();
            var customerNotUse = new Customer();

            logMock.Setup(u => u.LogWithRef(ref customerNotUse)).Returns(true);

            Assert.IsFalse(logMock.Object.LogWithRef(ref customer));
            Assert.IsTrue(logMock.Object.LogWithRef(ref customerNotUse));
        }

        //moq property
        [Test]
        public void BankAccount_logPropety_mockTest()
        {
            var logMock = new Mock<ILogBook>();
            logMock.SetupAllProperties();
            logMock.Setup(u => u.LogSeverity).Returns(100);
            logMock.Setup(u => u.LogType).Returns("warning");


            // logMock.Object.LogSeverity = 100;

            Assert.That(logMock.Object.LogSeverity, Is.EqualTo(100));
            Assert.That(logMock.Object.LogType, Is.EqualTo("warning"));

        }

        //log callback
        [Test]
        public void BankAccount_CallBack_mockTest()
        {
            var logMock = new Mock<ILogBook>();
            string logTemp = "Hello, ";
            logMock.Setup(u => u.LogToDb(It.IsAny<string>()))
                .Returns(true).Callback((string str) => logTemp += str);

            logMock.Object.LogToDb("Ben");
            Assert.That(logTemp, Is.EqualTo("Hello, Ben"));

            //callbacks
            int counter = 5;
            logMock.Setup(u => u.LogToDb(It.IsAny<string>()))
                .Callback(() => counter++)
                .Returns(true)
                .Callback(() => counter++);
            logMock.Object.LogToDb("Ben");
            logMock.Object.LogToDb("Ben");
            Assert.That(counter, Is.EqualTo(9));
        }
        //moq verify
        [Test]
        public void BankAccount_Verify_mockTest()
        {
            var logMock = new Mock<ILogBook>();
            var bankAccount = new BankAccount(logMock.Object);

            bankAccount.Deposit(100);

            Assert.That(bankAccount.Getbalance, Is.EqualTo(100));

            logMock.Verify(u => u.Message(It.IsAny<string>()), Times.Exactly(2));
            logMock.Verify(u => u.Message("Hi"), Times.AtLeastOnce);
            logMock.VerifySet(u => u.LogSeverity = 103, Times.Once);
            logMock.VerifyGet(u => u.LogSeverity, Times.Once);


        }


    }
}