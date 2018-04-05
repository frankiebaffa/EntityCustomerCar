using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EntityCustomerCar
{
    public class Car
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public Guid OwnerId { get; set; }
        
        public ICollection<Customer> Customers { get; set; }
    }
}
