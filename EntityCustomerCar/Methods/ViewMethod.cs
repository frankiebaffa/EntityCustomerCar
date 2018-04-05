using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCustomerCar
{
    public class ViewMethod
    {
        public static void View()
        {
            //  View contents of entire table
            using (var ctx = new CustomerCarContext())
            {
                //Display all customers in ctx
                //  Join Customers and Cars at Id and OwnerId
                //  respectively
                var query = from x in ctx.Customers
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
                                y.Color
                            };

                Console.WriteLine("All customers added:");
                Console.WriteLine();

                //  Iterate through table
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

    }
}
