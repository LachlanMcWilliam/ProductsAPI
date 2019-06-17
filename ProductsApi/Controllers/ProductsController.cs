using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BandQ.Data.Classes;

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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _context.Products.ToListAsync<Product>();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            //   var product = await _context.FindAsync<Product>(id);
            //var product = await _context.Products.Where(x => x.Id == id).ToListAsync();

            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(product);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Product recivedProduct)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == recivedProduct.Id);

            product.Name = recivedProduct.Name;
            product.Price = recivedProduct.Price;
            product.Stock = recivedProduct.Stock;
            product.Images = recivedProduct.Images;
            product.Description = recivedProduct.Description;

            _context.Products.Update(product);

            await _context.SaveChangesAsync();

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}