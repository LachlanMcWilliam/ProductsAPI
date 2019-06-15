using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Price { get; set; }
        public String Description { get; set; }
        public int Stock { get; set; }
        public decimal Weight { get; set; }
        public virtual List<Image> Images { get; set; }

    }
}
