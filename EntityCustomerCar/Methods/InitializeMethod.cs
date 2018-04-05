using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityCustomerCar.Methods;

namespace EntityCustomerCar
{
    public class InitializeMethod
    {
        public static void Initialize()
        {
            bool continueRun = true;

            while (continueRun == true)
            {
                continueRun = LoopMethod.LogicLoop(continueRun);
            }
        }
    }
}
