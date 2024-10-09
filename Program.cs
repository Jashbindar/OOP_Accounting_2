using System;

namespace OOP_Accounting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Option option_message = new Option();

            string name, email, password;
            char user_option;
            int id;
            double user_income, user_expense;

            Console.WriteLine("Enter your name:");
            name = Console.ReadLine();
            UserAccount account = new UserAccount();

            Console.WriteLine("Enter your email:");
            email =  Console.ReadLine();
            Console.WriteLine("Enter your password:");
            password = Console.ReadLine();
            Console.WriteLine("Enter your email:");
            id = Convert.ToInt32(Console.ReadLine());
            UserDetail userDetails = new UserDetail(email, password, id);

            while (true)
            {
                option_message.DisplayOption();
                Console.WriteLine("Enter your choice:");
                user_option = Convert.ToChar(Console.ReadLine());
                Option option = new Option(user_option);
                UserDetail userDetail = new UserDetail();

                switch (option.getUserOption())
                {
                    case '1':
                        Console.WriteLine("Please enter your income:");
                        user_income = Convert.ToInt32(Console.ReadLine());
                        TransactionIncome userIncome = new TransactionIncome(user_income, DateTime.Now);
                        account.addIncome(userIncome);
                        account.AddAccountBalance(user_income);
                        break;
                    case '2':
                        Console.WriteLine("Please enter your expenses:");
                        user_expense = Convert.ToInt32(Console.ReadLine());
                        TransactionExpense userExpense = new TransactionExpense(user_expense, DateTime.Now);
                        account.Add_Expense(userExpense);
                        account.MinusAccountBalance(user_expense);
                        break;
                    case '3':
                        break;
                    case '4':
                        break;
                    case '5':
                        break;
                    case '6':
                        break;
                    case '7':
                        break;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            }
        }
    }
}