using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandQ.Data.Classes
{
    public class Adress
    {
        public int Id { get; set; }
        //public int CustomerId { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }

        public virtual List<AdressToCustomer> AdressToCustomers { get; set; }
    }
}
