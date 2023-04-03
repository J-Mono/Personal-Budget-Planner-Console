using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Personal_budget_planning
{
    // a class tha contains the info about expenses
    class ExpensesEventArgs : EventArgs
    {
        // properties for expense that will attach itself to variable
        //for which information we want to give access to
        public Expense Expense { get; set; }
    }
}
