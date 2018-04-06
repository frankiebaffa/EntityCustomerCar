using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCustomerCar.Methods
{
    public class PhoneMethod
    {
        public static long PhoneAdd()
        {
            Console.WriteLine("Enter Customer's Phone Number");
            bool phoneResult = false;
            long phone = 0;

            //  Loop until a proper phone number is added
            while (phoneResult == false)
            {
                phoneResult = long.TryParse(Console.ReadLine(), out phone);
                Console.WriteLine();

                if (phoneResult == false)
                {
                    Console.WriteLine("Please Enter a Valid Phone Number (No Letters or Symbols)");
                }
                else
                {
                    phoneResult = CheckPhoneLength(phone, phoneResult);
                }
            }

            return phone;
        }
        public static bool CheckPhoneLength(long phone, bool phoneResult)
        {
            if (phone > 9999999999
                || phone < 1000000000)
            {
                Console.WriteLine("Please Enter a Valid Phone Number.");
                phoneResult = false;
            }
            else
            {
                phoneResult = true;
            }
            return phoneResult;
        }
    }
}
