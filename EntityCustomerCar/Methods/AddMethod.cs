using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCustomerCar
{
    public class AddMethod
    {
        public static void Add()
        {
            //  Add customer / car to table
            using (var ctx = new CustomerCarContext())
            {
                //  Accept first name as input
                Console.WriteLine("Enter Customer's First Name:");
                string firstName = Console.ReadLine();
                Console.WriteLine();

                //  Accept last name as input
                Console.WriteLine("Enter Customer's Last Name:");
                string lastName = Console.ReadLine();
                Console.WriteLine();

                //  Accept phone number as input, parse as string
                long phone = PhoneAdd();

                //  Grab current DateTime
                DateTime dateAdded = DateTime.Now;

                //  Create new customer object from input
                var customer = new Customer()
                {
                    Id = Guid.NewGuid(),
                    FirstName = firstName,
                    LastName = lastName,
                    Phone = phone,
                    DateAdded = dateAdded
                };

                //  Accept year of vehicle from input
                Console.WriteLine("Enter Year of Customer's Vehicle:");
                int year = int.Parse(Console.ReadLine());
                Console.WriteLine();

                //  Accept make from input
                Console.WriteLine("Enter Make of Customer's Vehicle:");
                string make = Console.ReadLine();
                Console.WriteLine();

                //  Accept model from input
                Console.WriteLine("Enter Model of Customer's Vehicle:");
                string model = Console.ReadLine();
                Console.WriteLine();

                //  Accept colour from input
                Console.WriteLine("Enter Colour of Customer's Vehicle:");
                string color = Console.ReadLine();
                Console.WriteLine();

                //  Create new car object from inputs
                var car = new Car()
                {
                    Id = Guid.NewGuid(),
                    Year = year,
                    Make = make,
                    Model = model,
                    Color = color,
                    OwnerId = customer.Id
                };

                //  Add car to customer object
                customer.Car = car;

                //  Add to table
                ctx.Customers.Add(customer);
                ctx.Cars.Add(car);
                ctx.SaveChanges();
            }
        }

        public static long PhoneAdd()
        {
            Console.WriteLine("Enter Customer's Phone Number");
            bool phoneLoop = false;
            long phone = 0;
            while (phoneLoop == false)
            {
                phone = long.Parse(Console.ReadLine());
                Console.WriteLine();
                phoneLoop = true;
            }

            return phone;
        }

    }
}
