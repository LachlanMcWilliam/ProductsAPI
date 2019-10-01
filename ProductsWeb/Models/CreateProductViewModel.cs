using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsWeb.Models
{
    public class CreateProductViewModel
    { 
        [Required]
        [StringLength(30)]
        public String Name { get; set; }
        [Required]
        [Range(0,1500)]
        public Decimal Price { get; set; }
        public String Description { get; set; }
        [Required]
        [Range(0,9999)]
        public int Stock { get; set; }
    }
}
