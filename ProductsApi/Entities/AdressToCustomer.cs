using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.Entities
{
    public class AdressToCustomer
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AdressId { get; set; }
        public virtual Adress Adress { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
