using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EntityCustomerCar
{
    public class Customer
    {
        public Customer()
        { }

        public Customer(string firstName, string lastName, long phone, DateTime dateAdded)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            DateAdded = dateAdded;
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Phone { get; set; }
        public DateTime DateAdded { get; set; }

        public Car Car { get; set; }

    }
}
