
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace Personal_budget_planning
{
    class Program
    {
        static void Main(string[] args)
        {   //Exception handing 
            try //identifies the code to active the type of exception on(Tutorialspoint, 2021)
            {
                menu();
                ReadLine();
            }
            catch (Exception e)// Captures the exception in place(Tutorialspoint, 2021)
            {
                WriteLine("************There seems to be an issue*************");// display error message
                WriteLine("Description of exception: "+e.Message);
                WriteLine("Source: "+e.Source+"\n");
                QuitProgram();//Calling method for ending the program
                Read();//reads line from the file and  returns it as a string
            } 
        }
        public static void menu()
        {
            Expense user = new HomeLoan() {};//Subscriber of event
            var ExpensesWarning = new ExpensesWarning();//publisher of the event 
            Expense User1 = new Buy_A_Vehicle();//new Buy a vehicle object

            WriteLine("Welcome to the Budget Planner\n" +
                      "***Record monthly spendings***take control of your money***\n" +
                     "Let's get started! \n");//Messsage to welcome the user
            
            //displaying menu
            Write("Main Menu");
            WriteLine("\n<< 1 >>Expense & Homeloan"+"\n<< 2 >>Buy A Vehicle");
            Write("Select Option: ");
            int option = Convert.ToInt32(ReadLine());//taking in input option
            //switch statements allow a variable to be tested against a list of values (tutorialspoint, 2021)
            switch (option)
            {
                case 1:
                    user.Message();//the object takes the method from the homeLoan class
                    //subscribing Expense object
                    //Publisher. event // (+=) subscribing // pointing to the object in the subscriber class
                    ExpensesWarning.ExpensesWarned += user.OnExpensesWarned;
                    //calling the ExpensesWarn method after subscribing Expense
                    //ExpensesWarn method is a raised event
                    ExpensesWarning.ExpensesWarn(user);

                    QuitProgram();//method that forces the end of a program
                    break;
                case 2:
                    User1.Message();
                    QuitProgram();
                    break;
                default:
                    QuitProgram();
                    break;
            }
        }
        public static void QuitProgram()//Method that forces the program to end
        {
            Write("Press ENTER twice to quit... ");//prompts user for any value
            // Console.ReadKey()reads the next characters from the standard input stream (Tutorialspoint, 2021)
            // Console.ReadKey() can be used to ask to press the enter key to exit
            while (ReadKey(true).Key != ConsoleKey.Enter){
            }
        }
    }
}
