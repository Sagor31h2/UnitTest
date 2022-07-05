namespace Sparky
{
    public class BankAccount
    {

        private int balance { get; set; }

        public BankAccount()
        {
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
            balance += ammount;
            return true;
        }

        //withdraw
        public bool Withdraw(int ammount)
        {
            if (balance >= ammount)
            {
                balance -= ammount;
                return true;
            }
            return false;
        }

    }
}
