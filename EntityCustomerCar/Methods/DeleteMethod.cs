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
                
                var queryDelete = ctx.Customers.Where(x => x.LastName == deleteCustomer);

                if (queryDelete.Count() > 1)
                {

                    Console.WriteLine(string.Format("There are multiple {0}'s in the system." +
                        " Please enter the number left of the customer you wish to delete.",
                        deleteCustomer));
                    Console.WriteLine();

                    string deleteResult = "";

                    int i = 0;
                    Dictionary<int, string> deleteDictionary = new Dictionary<int, string>();
                    var query = from x in ctx.Customers.Where(x => x.LastName == deleteCustomer)
                                join y in ctx.Cars
                                on x.Id equals y.OwnerId
                                orderby x.LastName

                                //  Place custom/newely joined table in query
                                select new
                                {
                                    x.FirstName,
                                    x.LastName,
                                    x.Phone,
                                    y.Year,
                                    y.Make,
                                    y.Model,
                                    y.Color,
                                    x.Id
                                };

                    foreach (var item in query)
                    {
                        i++;
                        deleteResult = string.Format("{0}: {1} {2} - {3} : {4} {5} {6} ({7})",
                        i, item.FirstName, item.LastName, item.Phone,
                        item.Year, item.Make, item.Model, item.Color);
                        deleteDictionary.Add(i, item.Id.ToString());

                        Console.WriteLine(deleteResult);
                    }

                    Console.WriteLine();
                    int deleteCustomerInt = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    string deleteDictionaryValue = (from x in deleteDictionary
                                                    where x.Key == deleteCustomerInt
                                                    select x.Value).Single();

                    var delete = (from x in ctx.Customers
                                  where x.Id.ToString() == deleteDictionaryValue
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
                    foreach (var item in queryDelete)
                    {
                        string queryResult = string.Format(
                            "{0} {1} - {2}", item.FirstName, item.LastName,
                            item.Phone);

                        Console.WriteLine(queryResult);
                        Console.WriteLine("DELETED");
                        Console.WriteLine();
                    }

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
