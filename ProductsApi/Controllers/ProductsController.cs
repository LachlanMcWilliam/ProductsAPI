using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BandQ.Data.Classes;
using BandQ.Commons.Services;
using BandQ.Commons.Services.Models;
using System.Net;
using Swashbuckle.Swagger.Annotations;
using ProductsApi.Filters;
using ProductsApi.Attributes;

namespace ProductsApi.Controllers
{

    [ServiceFilter(typeof(TLSDetection))]

    [Route("api/[controller]")]
    [ApiController]
    [AddHeader("Author", "Joe Smith")]
    [ATLSDetection]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        //private readonly Context _context;

        //public ProductsController(Context context)
        //{
        //    _context = context;
        //}

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        /// <summary>
        /// Posts a ProductModel
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(ProductModel product)
        {
            //_context.Add<Product>(product);
            //await _context.SaveChangesAsync();

            var result = await _service.AddProduct(product);

            return Ok(result);
        }

        /// <summary>
        /// Get a list of products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //var products = await _context.Products.ToListAsync<Product>();
            //return Ok(products);

            var products = await _service.GetProducts();

            return Ok(products);

            //return Ok();
        }

        /// <summary>
        /// Get a product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SwaggerOperation("ANY OPERATION")]
        //[SwaggerResponse((int)HttpStatusCode.OK, typeof(ProductModel))]
        //[SwaggerResponse((int)HttpStatusCode.Accepted, typeof(ProductModel))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized)]
        //[SwaggerResponse((int)HttpStatusCode.InternalServerError, typeof(ErrorModel))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            //   var product = await _context.FindAsync<Product>(id);
            //var product = await _context.Products.Where(x => x.Id == id).ToListAsync();

            //var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            //return Ok(product);


            return Ok(await _service.GetProductById(id));
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="recivedProduct"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(ProductModel recivedProduct)
        {
            var result = await _service.UpdateProduct(recivedProduct);

            return Ok(result);
        }

        /// <summary>
        /// Delete a product by it's id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SwaggerOperation("ANY OPERATION")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.Accepted)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            //_context.Products.Remove(product);
            //await _context.SaveChangesAsync();

            await _service.DeleteProduct(new ProductModel
            {
                Id = id
            });

            return Ok();
        }
    }
}