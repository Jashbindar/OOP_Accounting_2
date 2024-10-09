using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Accounting
{
    internal class TransactionExpense
    {
        private double Expense {  get; set; }
        private DateTime Date_of_expense {  get; set; }

        public TransactionExpense(double expense, DateTime date_of_expense)
        {
            Expense = expense;
            Date_of_expense = date_of_expense;
        }

        public TransactionExpense() { }

        public double getExpense() { return Expense; }
        public DateTime getDate_of_expense() { return Date_of_expense; }
    }
}
