using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityCustomerCar.Methods;

namespace EntityCustomerCar
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueRun = true;

            while (continueRun == true)
            {
                continueRun = LoopMethod.LogicLoop(continueRun);
            }
        }
    }
}
