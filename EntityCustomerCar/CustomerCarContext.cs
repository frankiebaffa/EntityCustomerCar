using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EntityCustomerCar
{
    class CustomerCarContext : DbContext
    {
        public CustomerCarContext() : base()
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
