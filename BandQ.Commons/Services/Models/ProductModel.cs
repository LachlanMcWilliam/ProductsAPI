using System;
using System.Collections.Generic;
using System.Text;

namespace BandQ.Commons.Services.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public decimal Price { get; set; }
        public String Description { get; set; }
        public int Stock { get; set; }
        public decimal Weight { get; set; }
        public decimal WieghtPounds { get {
                return this.Weight * 2; }
        }
    }
}
