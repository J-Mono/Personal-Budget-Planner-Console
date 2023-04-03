using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Personal_budget_planning
{
    class Buy_A_Vehicle : Expense
    {
        public static Double Price { get; set; }
        public static Double Deposit { get; set; }
        private static Double Interest { get; set; }
        private static Double premium { get; set; }

        public override void Message()
        {
            Clear();//clearing the screen
            WriteLine("Hi! Welcome to car budget section of the application.");//Messsage to welcome the user
            choice();//Calling method for choice making
        }
        public override void choice() 
        {
            WriteLine("Would you like to buy a new Car?");
            Write("Enter Y/N (yes/no): ");//prompts the user to enter either Y or N
            string Yes_Or_No = ReadLine();
            if (Yes_Or_No == "Y")// Y means yes
                Buy();
            else if (Yes_Or_No == "N") //N means no
                Environment.Exit(0);//if N is selected, program will close
        }
        public override void Buy()
        {
            Clear();
            string[] vehicle_financing = {"Puchase Price","Total deposit",
                                        "Interest rate (percentage)", "Estimated insurance premium"};
            Write("Enter the following values for the vehicle finance \n"+ "Model and make" + ": ");
            string Model = ReadLine();

            Double[] value = { Price, Deposit, Interest, premium };
            for (int IndexNumber = 0; IndexNumber < vehicle_financing.Length; IndexNumber++)
            {
                Write(vehicle_financing[IndexNumber] + ": ");
                value[IndexNumber] = Double.Parse(ReadLine());//The value for tax
            }
            //passing the array values into parameters
            Price = value[0];
            Deposit = value[1];
            Interest = value[2];
            premium = value[3];
            Total_Monthly_Costs(Price, Deposit, Interest, premium, Model);
        }
        private static void Total_Monthly_Costs(Double Price, Double Deposit, Double Interest, Double premium, string Model)
        {
            int number_Of_months;
            Write("number of repayment months: ");
            number_Of_months = Convert.ToInt32(ReadLine());
            //The Loan is calculated using simple ineterest, since this Loan repayment is about hire purchase
            Price -= Deposit;//Price = Price - Deposit
            int Years = number_Of_months / 12;// Years is calculate by dividng repayment months by 12
            Interest = Interest / 100; //interest is calculated by dviding a value by 100 to get the percentage 
            Double Accumulated_amount = Price * (1 + (Interest * Years));//simple interest is calculated
            Double Monthly_repay = (Accumulated_amount / number_Of_months) + premium;//repayemnt is calculated
            
            WriteLine("\nThe monthly cost for the {1} is {0}", Monthly_repay, Model);//repayment is printed
            ReadLine();
        }
    }
}
