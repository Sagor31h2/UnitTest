using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sparky
{
    public interface ILogBook
    {
        public int LogSeverity { get; set; }
        public string LogType { get; set; }
        void Message(string message);
        bool LogToDb(string message);

        bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal);
        string LogReturnString(string message);
        bool LogWithOutput(string str, out string outStr);
        bool LogWithRef(ref Customer customer);
    }
    public class LogBook : ILogBook
    {
        public int LogSeverity { get; set; }
        public string LogType { get; set; }
        public bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal)
        {
            if (balanceAfterWithdrawal >= 0)
            {
                Console.WriteLine("Success");
                return true;
            }
            Console.WriteLine("Failed");
            return false;
        }

        public string LogReturnString(string message)
        {
            Console.WriteLine(message);
            return message;
        }

        public bool LogToDb(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public bool LogWithOutput(string str, out string outStr)
        {
            outStr = "Hello " + str;
            return true;
        }

        public bool LogWithRef(ref Customer customer)
        {
            return true;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }
    }
}