using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Entities;

namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly Context _context;

        public ProductsController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            _context.Add<Product>(product);
            await _context.SaveChangesAsync();
            return Ok();
        }

        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}