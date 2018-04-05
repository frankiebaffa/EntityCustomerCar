using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EntityCustomerCar
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueRun = true;

            while (continueRun == true)
            {
                Console.WriteLine("Would you like to add a customer (add), view all customers (view), or exit (exit)?");
                string programAction = Console.ReadLine();
                Console.WriteLine();

                if (programAction == "add"
                    || programAction == "Add")
                {
                    using (var ctx = new CustomerCarContext())
                    {
                        Console.WriteLine("Enter Customer's First Name:");
                        string firstName = Console.ReadLine();
                        Console.WriteLine();

                        Console.WriteLine("Enter Customer's Last Name:");
                        string lastName = Console.ReadLine();
                        Console.WriteLine();

                        Console.WriteLine("Enter Customer's Phone Number");
                        long phone = long.Parse(Console.ReadLine());
                        Console.WriteLine();

                        DateTime dateAdded = DateTime.Now;

                        var customer = new Customer()
                        {
                            Id = Guid.NewGuid(),
                            FirstName = firstName,
                            LastName = lastName,
                            Phone = phone,
                            DateAdded = dateAdded
                        };

                        Console.WriteLine("Enter Year of Customer's Vehicle:");
                        int year = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        Console.WriteLine("Enter Make of Customer's Vehicle:");
                        string make = Console.ReadLine();
                        Console.WriteLine();

                        Console.WriteLine("Enter Model of Customer's Vehicle:");
                        string model = Console.ReadLine();
                        Console.WriteLine();

                        Console.WriteLine("Enter Colour of Customer's Vehicle:");
                        string color = Console.ReadLine();
                        Console.WriteLine();

                        var car = new Car()
                        {
                            Id = Guid.NewGuid(),
                            Year = year,
                            Make = make,
                            Model = model,
                            Color = color,
                            OwnerId = customer.Id
                        };

                        customer.Car = car;

                        ctx.Customers.Add(customer);
                        ctx.Cars.Add(car);
                        ctx.SaveChanges();
                    }
                }
                else if (programAction == "exit"
                    || programAction == "Exit")
                {
                    continueRun = false;
                }
                else if (programAction == "view"
                    || programAction == "View")
                {
                    using (var ctx = new CustomerCarContext())
                    {
                        //Display all customers in db
                        var query = from x in ctx.Customers
                                    join y in ctx.Cars
                                    on x.Id equals y.OwnerId
                                    orderby x.LastName
                                    select new
                                    {
                                        x.FirstName,
                                        x.LastName,
                                        x.Phone,
                                        y.Year,
                                        y.Make,
                                        y.Model,
                                        y.Color
                                    };

                        Console.WriteLine("All customers added:");
                        Console.WriteLine();
                        foreach (var item in query)
                        {
                            string resultString = string.Format("{0} {1} - {2} : {3} {4} {5} ({6})",
                                item.FirstName, item.LastName, item.Phone,
                                item.Year, item.Make, item.Model, item.Color);

                            Console.WriteLine(resultString);
                            Console.WriteLine();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Command not found.");
                    Console.WriteLine();
                }
            }
        }
    }
}
