using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using System.Collections.Generic;

namespace Personal_budget_planning
{
    abstract class Expense
    {
        //Short handing getters and setters(w3schools, 2021)
        public static Double Gross_Income { get; set; }
        public static Double tax { get; set; }
        private static Double groceries { get; set; }
        private static Double Water_lights { get; set; }
        private static Double travel_costs { get; set; }
        private static Double phone { get; set; }
        private static Double others { get; set; }
        
        //created an array to store the value inputs for each expense
        //Arrays are used to store multiple values in one variable (w3schools, 2021)
        //public static Double[] expensesAmounts = { groceries, Water_lights, travel_costs, phone, others };

        public Double Total_expenses { get; set; }//will store the total value of all expenses listed
        //Calling the method that takes in values for deduction calculations

        static List<string> expenses = new List<string>();//placing expenses in a collection
        static List<Double> expensesAmounts = new List<Double>();//placing expenses values in a collection
        public static void EnterValues()
        {
            Clear();
            //collection are for data storage and retrieval (tutorialspoint, 2021)
            expenses.Add("Groceries");
            expenses.Add("Water and Lights");
            expenses.Add("Travel costs (including petrol");
            expenses.Add("Cell phone and telephone");
            expenses.Add("Other expenses");

            expensesAmounts.Add(groceries);
            expensesAmounts.Add(Water_lights);
            expensesAmounts.Add(travel_costs);
            expensesAmounts.Add(phone);
            expensesAmounts.Add(others);

            Write("Enter The following: \n" + "Income before deduction: R");//Prompting user to enter the value for gross income
            Gross_Income = Double.Parse(ReadLine());//The value for Gross Income

            Write("Monthly tax deducted (estimate amount): R");
            tax = Double.Parse(ReadLine());//The value for tax

            WriteLine("Enter Estimated Monthly Expenditures: ");
            //For-loop is used to loop through the expenses and Amount inputs for each expense
            //for-loops allow you to loop for a set number of times  (Tutorialspoint, 2021)
            for (int IndexNumber = 0; IndexNumber < 5; IndexNumber++)
            {
                Write(expenses[IndexNumber] + ": R");
                expensesAmounts[IndexNumber] = Double.Parse(ReadLine());
            }
        }
        public static void Display_expenses()
        {   
            WriteLine("\n");
            //sorting the expenses in descending order by values
            //First, a value comparer was used to compare the amounts for each expense 
            var descendingComparer = Comparer<Double>.Create((x, y) => y.CompareTo(x));

            //then a sorted list was made to store the expenses and there amounts
            // a SortedList are collection classes that can store key-value pairs (tutorialsteacher, 2020)
            SortedList<Double, string> descSortedList = new SortedList<Double, string>(descendingComparer);
            descSortedList.Add(expensesAmounts[0], expenses[0]);
            descSortedList.Add(expensesAmounts[1], expenses[1]);
            descSortedList.Add(expensesAmounts[2], expenses[2]);
            descSortedList.Add(expensesAmounts[3], expenses[3]);
            descSortedList.Add(expensesAmounts[4], expenses[4]);

            //the for loop was then used to print out the expenses in descending order
            //based on their values
            for (int i = 0; i < descSortedList.Count; i++)
            {
                WriteLine("{1}: {0}", descSortedList.Keys[i], descSortedList.Values[i]);
            }
        }
        //Abstract methods declared to be used by any class that inherits from expense
        //The body is supplied by the child classes for these methods (w3schools, 2021)
        public abstract void Message();
        public abstract void Buy();
        public abstract void choice();

        //Method to calculate the amount available after deduction of Gross Income
        public void available_monthly_money(Double rent, Double Monthly)
        {
            /*calculating available amount.\
             * Note: if user did not choose rent, then rent is 0.
             if user did not choose buy, then monthly is 0.*/
            Total_expenses = expensesAmounts.Sum();
            Gross_Income = Gross_Income - Total_expenses - tax - rent - Monthly;
            Write("The amount available monthly (after deductions): {0} \n", Gross_Income);//displaying available amount
            Read();//reads line from the file and  returns it as a string
        }

        //creating an eventhandler for the publisher's pointer , in Program.cs, to point to
        //pointer found at user.OnExpensesWarned; in Program.cs
        public void OnExpensesWarned(object source, ExpensesEventArgs e)
        {
            Double percentage_income = Gross_Income * 3 / 4;//calculating 75% of the user income
            //if the value retrieved for total expenses is more that 75%...
            //of the user income
            if (e.Expense.Total_expenses > percentage_income)
            {
                //then print the following
                Display_expenses();
                WriteLine("\nTotal expenses: " + e.Expense.Total_expenses);//total expense
                WriteLine("Expenses are more than 75% of your income.");//warning message
            }
            else //otherwise
            {
                //end the program
                WriteLine("Closing program...");
                Thread.Sleep(2000);//stalls the prgram for 2 seconds. this is to simulate loading
                Environment.Exit(0);
            }
            ReadLine();
        }
    }
}
