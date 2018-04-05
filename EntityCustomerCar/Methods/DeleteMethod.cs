using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCustomerCar
{
    public class DeleteMethod
    {
        public static void Delete()
        {
            //  Delete customer and their car from database
            using (var ctx = new CustomerCarContext())
            {
                //  Use customer last name from input
                Console.WriteLine("Enter Customer Last Name You Wish To Delete");
                string deleteCustomer = Console.ReadLine();
                Console.WriteLine();

                //  Query customers for matches
                var queryDelete = from x in ctx.Customers
                                  where x.LastName == deleteCustomer
                                  select x;

                foreach (var item in queryDelete)
                {
                    string queryResult = string.Format(
                        "{0} {1} - {2}", item.FirstName, item.LastName,
                        item.Phone);

                    Console.WriteLine(queryResult);
                    Console.WriteLine();
                }

                if (queryDelete.Count() > 1)
                {

                    Console.WriteLine(string.Format("There are multiple {0}'s in the system." +
                        " Please enter the phone number of whome you wish to delete.", deleteCustomer));

                    long deleteCustomerPhone = long.Parse(Console.ReadLine());
                    Console.WriteLine();

                    var delete = (from x in ctx.Customers
                                  where x.Phone == deleteCustomerPhone
                                  select x).Single();

                    var carDelete = (from x in ctx.Cars
                                     where x.OwnerId == delete.Id
                                     select x).Single();

                    ctx.Customers.Remove(delete);
                    ctx.SaveChanges();

                    ctx.Cars.Remove(carDelete);
                    ctx.SaveChanges();

                }
                else if (queryDelete.Count() == 1)
                {

                    //  Use customer last name to locate customer
                    var delete = (from x in ctx.Customers
                                  where x.LastName == deleteCustomer
                                  select x).Single();

                    //  Use Id from customer to locate their vehicle
                    var carDelete = (from x in ctx.Cars
                                     where x.OwnerId == delete.Id
                                     select x).Single();

                    //  Delete customer from table
                    ctx.Customers.Remove(delete);
                    ctx.SaveChanges();

                    //  Delete car from table
                    ctx.Cars.Remove(carDelete);
                    ctx.SaveChanges();

                }
            }
        }
    }
}
