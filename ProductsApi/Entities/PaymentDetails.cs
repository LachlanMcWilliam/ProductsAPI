using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.Entities
{
    public class PaymentDetails
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CardNumber { get; set; }
        public DateTime ExpireyDate { get; set; }
        public string NameOnCard { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
