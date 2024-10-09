using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Accounting
{
    internal class Option
    {
        private char User_Option {  get; set; }

        public Option(char user_option)
        {
            User_Option = user_option;
        }
        public Option() { }

        public char getUserOption()
        {
            return User_Option;
        }

        public void DisplayOption()
        {
            Console.WriteLine("\n1. Add Income");
            Console.WriteLine("2. Add Expenses");
            Console.WriteLine("3. View Account Balance");
            Console.WriteLine("4. View Transaction History");
            Console.WriteLine("5. Remove Income");
            Console.WriteLine("6. Remove Expense");
            Console.WriteLine("7. Quit\n");
        }
    }
}
