using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCustomerCar.Methods
{
    public class LoopMethod
    {
        public static bool LogicLoop(bool continueRun)
        {
            //  Prompt user for action
            Console.WriteLine("Would you like to add a customer (add), delete a customer (delete), view all customers (view), or exit (exit)?");
            string programAction = Console.ReadLine();
            Console.WriteLine();

            //  Add, View, Delete, Exit
            if (programAction == "add"
                || programAction == "Add")
            {
                //  Add method
                AddMethod.Add();
                return continueRun;
            }
            else if (programAction == "view"
              || programAction == "View")
            {
                //  View method
                ViewMethod.View();
                return continueRun;
            }
            else if (programAction == "delete"
              || programAction == "Delete")
            {
                //  Delete method
                DeleteMethod.Delete();
                return continueRun;
            }
            else if (programAction == "exit"
            || programAction == "Exit")
            {
                //  Exit program
                continueRun = false;
                return continueRun;
            }
            else
            {
                //  Show error, return to loop
                Console.WriteLine("Command not found.");
                Console.WriteLine();
                return continueRun;
            }
        }
    }
}
