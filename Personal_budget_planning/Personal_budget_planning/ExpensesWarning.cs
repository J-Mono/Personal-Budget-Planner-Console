using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Personal_budget_planning
{
    class ExpensesWarning
    {
        //declaring a delgate with two parameters: the source of the event and the extra info we want to send
        //declaring an event handler
        //event handlers are responsible for dealing with events (More, 2020)
        public delegate void ExpensesWarningEventHandler(object source, ExpensesEventArgs args);
        //declaring an event
        public event ExpensesWarningEventHandler ExpensesWarned;
        
        //raising an event
        public void ExpensesWarn(Expense expense)
        {
            WriteLine("Checking if expenses is less or more than limit...");
            Thread.Sleep(2000);//stalls the prgram for 2 seconds. this is to simulate loading(Microsoft, 2021)
            OnExpensesWarned(expense);
        }

        //publishing an event
        protected virtual void OnExpensesWarned(Expense expense)
        {
            //checking for subscribers
            if (ExpensesWarned != null)
                ExpensesWarned(this, new ExpensesEventArgs() {Expense = expense});
        }
    }
}
