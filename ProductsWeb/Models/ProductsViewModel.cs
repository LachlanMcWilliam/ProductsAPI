using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsWeb.Models
{
    public class ProductsViewModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Decimal Price { get; set; }
        public String Description { get; set; }
        public int Stock { get; set; }
    }
}
