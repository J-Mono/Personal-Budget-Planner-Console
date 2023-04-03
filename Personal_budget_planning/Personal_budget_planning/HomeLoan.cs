using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Personal_budget_planning
{
    class HomeLoan : Expense //Homeloan inherits from expense (guru99, 2021)
    {
        //allows subclass to give a specific implementation (Fundamentals, 2020)
        public override void Message()// implementing inherited abstract member Message from expense
        {
            EnterValues();// calling EnterValue method form expense
            choice();//Calling method for choice making
        }
        public override void choice()// implementing inherited abstract member Choice from expense
        {   
            //Clears the page to introduce a new display
            Clear();
            //Prompts user to choose between 1 and 2 for the following
            Write("Accomodation \n" +
                 "If you choose rent, enter 1 \n" +
                 "If you choose to buy property, enter 2 \nchoice: ");
            int Choice = Convert.ToInt32(ReadLine());//takes user choice
            //if statements read a block of code according to a condition(w3schools, 2021)
            if (Choice == 1)//if user enters 1
                Rent(); // the rent method is used
            else if(Choice == 2)//if user enters 2
                Buy();// the buy method is called  
        }
        private void Rent()//Method to enter rent amount
        {
            Clear();//page is cleared
            Write("Enter the monthly rent amount: ");//user is asked to enter rent amount
            Double Rent = Double.Parse(ReadLine());//this takes in rent amount
            Clear();//page is cleared
            WriteLine("Monthly Rent is now: {0}", Rent);//Rent message is displayed
            Write("Income: {0}\n", Gross_Income);//monthly income is displayed
            available_monthly_money(Rent,0);// this method will show the available amount after deductions
            Read();
        }
        public override void Buy()// implementing inherited abstract member Buy from expense
        {
            Clear();//page is cleared
            //in this method the user is asked to enter the values for each case
            Write("Enter the following Values: \n"+
                  "Purchase price of property: ");
            int Price = Convert.ToInt32(ReadLine());//Accepts user input for price

            Write("Total deposit: ");
            int Deposit = Convert.ToInt32(ReadLine());//Accepts user input for deposit

            Write("Interest rate (Percentage): ");
            Double Interest = Double.Parse(ReadLine());//Accepts user input for interest

            Write("Number of repayment months: ");
            int number_Of_months = Convert.ToInt32(ReadLine());//Accepts user input for number of repayment months 

            /*all the accepted values are put into this method's parameters 
             * in order for the method to calculate Loan repayment*/
            Loan_Calculator(Price, Deposit, Interest, number_Of_months);
        }
        //method to calculate loan repayment
        private void Loan_Calculator(int Price, int Deposit, Double Interest, int number_Of_months)
        {
            //The Loan is calculated using simple ineterest, since this Loan repayment is about hire purchase
            Price -= Deposit;//Price = Price - Deposit
            int Years = number_Of_months / 12;// Years is calculate by dividng repayment months by 12
            Interest = Interest / 100; //interest is calculated by dviding a value by 100 to get the percentage 
            Double Accumulated_amount = Price * (1 + (Interest * Years));//simple interest is calculated
            Double Monthly_repay = Accumulated_amount / number_Of_months;//repayemnt is calculated

            WriteLine("\nThe monthly repay is {0}", Monthly_repay);//repayment is printed
            Warning(Monthly_repay);//repayment gets passed into to Warning method
            ReadLine();
        }
        //this method checks if the monthly repay is not taking too much of user Income
        private void Warning(Double Monthly)
        {
            Double third_Of_Income = Gross_Income / 3;//third of user income is calculated
            if (Monthly > third_Of_Income)//if the repayment is greater than a third of the user Gross Income
                WriteLine("***WARNING***\n the amount for Monthly repay is greater than a third of your Income." +
                        "\n Income: {0} \n Monthly repay: {1}", Gross_Income, Monthly);//display warning message
            else//otherwise
                WriteLine("Monthly repay is less than or equal to a third of your Income.\n-->You are safe :)" +
                          "\n Income: {0} \n Monthly repay: {1}", Gross_Income, Monthly);//notify user that the amount is safe
            available_monthly_money(0,Monthly);// this method will show the available amount after deductions
        }
    }
}
