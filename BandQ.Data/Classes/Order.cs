using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandQ.Data.Classes
{
    public class Order
    {
        public int Id { get; set; }
        public int AdressId { get; set; }
        public int PaymentId { get; set; }
        public int CustomerId { get; set; }
        public int NumberOfProducts { get; set; }
        public bool HasBeenOrdered { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual PaymentDetails PaymentDetail { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
