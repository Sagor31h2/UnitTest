namespace Sparky
{
    public class BankAccount
    {

        private int balance { get; set; }
        private readonly ILogBook _logbook;

        public BankAccount(ILogBook logBook)
        {
            _logbook = logBook;
            balance = 0;
        }

        //Get balance
        public int Getbalance()
        {
            return balance;
        }

        //deposit
        public bool Deposit(int ammount)
        {
            _logbook.Message("Deposite is invoked");
            balance += ammount;
            return true;
        }

        //withdraw
        public bool Withdraw(int ammount)
        {
            // _logbook.Message("Withdraw is invoked");

            if (balance >= ammount)
            {
                balance -= ammount;
                return true;
            }
            return false;
        }

    }
}
