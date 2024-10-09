using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Accounting
{
    internal class UserAccount : People
    {
        private double User_Account_Balance { get; set; }
        private TransactionIncome User_Income { get; set; }
        private TransactionExpense User_Expense { get; set; }
        public UserDetail User_Details { get; set; }

        private List<TransactionIncome> Incomes = new List<TransactionIncome>();
        private List<TransactionExpense> Expenses = new List<TransactionExpense>();

        public UserAccount() { }
        public UserAccount(string name, int age, UserDetail userDetail) : base (name, age)
        {
            User_Details = userDetail;
        }
        public UserAccount(double user_account_balance, string name) : base(name)
        {
            User_Account_Balance = user_account_balance;
            User_Details = new UserDetail();
        }
        public UserAccount(string name) : base(name) { }
        public void addIncome(TransactionIncome income)
        {
            Incomes.Add(income);
            Console.WriteLine("Income transacion of RM{0} made on {1} has been added!", income.getIncome(), income.getDate_of_income());
        }

        public void removeIncome(TransactionIncome income)
        {
            Incomes.Remove(income);
            Console.WriteLine("Income transacion of RM{0} made on {1} has been removed!", income.getIncome(), income.getDate_of_income());
        }

        public TransactionIncome findIdOfTransactionIncome(int transaction_index)
        {
            if (transaction_index <= 0)
            {
                Console.WriteLine("Please enter a valid option!");
                return null;
            }
            for (int i = 0; i < Incomes.Count(); i++)
            {
                if (transaction_index - 1 == i)
                {
                    return Incomes[i];
                }
            }
            Console.WriteLine("Transaction not found");
            return null;
        }

        public void Add_Expense(TransactionExpense expense)
        {
            Expenses.Add(expense);
            Console.WriteLine("Expense transacion of RM{0} made on {1} has been added!", expense.getExpense(), expense.getDate_of_expense());
        }

        public void Remove_Expense(TransactionExpense expense)
        {
            Expenses.Remove(expense);
            Console.WriteLine("Expense transacion of RM{0} made on {1} has been removed!", expense.getExpense(), expense.getDate_of_expense());
        }

        public TransactionExpense findIdOfTransactionExpense(int transaction_index)
        {
            if (transaction_index <= 0)
            {
                Console.WriteLine("Please enter a valid option!");
                return null;
            }
            for (int i = 0; i < Expenses.Count(); i++)
            {
                if (transaction_index - 1 == i)
                {
                    return Expenses[i];
                }
            }
            Console.WriteLine("Transaction not found");
            return null;
        }
        public void AddAccountBalance(double income)
        {
            User_Account_Balance += income;
        }
        public void MinusAccountBalance(double expense)
        {
            User_Account_Balance -= expense;
        }

        public void DisplayAccountBalance()
        {
            Console.WriteLine("Your account balance is: RM {0}", Math.Round(User_Account_Balance, 2));
        }

        public void ViewTransactionHistory(int counter)
        {
            if (counter == 0)
            {
                Console.WriteLine("No history available");
            }
            else
            {
                Console.WriteLine("\n********************");
                Console.WriteLine("TRANSACTION HISTORY");
                Console.WriteLine("********************\n");
                Console.WriteLine("{0, -5} {1, -10} {2, -25} {3, -5} {4, -10} {5, -25}", "No.", "Income", "Transaction Date", "No.", "Expense", "Transaction Date");
                for (int i = 0; i < counter; i++)
                {
                    string incomeVal;
                    string incomeDate;
                    string income_index;

                    string expenseVal;
                    string expenseDate;
                    string expense_index;
                    if (i < Incomes.Count)
                    {
                        incomeVal = Convert.ToString(Incomes[i].getIncome());
                        incomeDate = Convert.ToString(Incomes[i].getDate_of_income());
                        income_index = Convert.ToString(i + 1);
                    }
                    else
                    {
                        incomeVal = "";
                        incomeDate = "";
                        income_index = "";
                    }
                    if (i < Expenses.Count)
                    {
                        expenseVal = Convert.ToString(Expenses[i].getExpense());
                        expenseDate = Convert.ToString(Expenses[i].getDate_of_expense());
                        expense_index = Convert.ToString(i + 1);
                    }
                    else
                    {
                        expenseVal = "";
                        expenseDate = "";
                        expense_index = "";
                    }
                    Console.WriteLine("{0, -5} {1, -10} {2, -25} {3, -5} {4, -10} {5, -25}", income_index, incomeVal, incomeDate, expense_index, expenseVal, expenseDate);
                }
            }
        }
    }
}
