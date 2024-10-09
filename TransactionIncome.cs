using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Accounting
{
    internal class TransactionIncome
    {
        private double Income { get; set; }
        private DateTime Date_of_income { get; set; }
        public TransactionIncome(double income, DateTime date_of_income)
        {
            Income = income;
            Date_of_income = date_of_income;
        }
        public double getIncome() { return Income; }
        public DateTime getDate_of_income() { return Date_of_income; }
    }
}
