using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        //public int AdressId { get; set; }
        //public int OrderId { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual List<PaymentDetails> PaymentDetails { get; set; }
        //public virtual List<Order> Orders { get; set; }
        public virtual List<AdressToCustomer> AdressToCustomers { get; set; }
    }
}
