using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BandQ.Commons.Services;
using BandQ.Commons.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductsWeb.Models;

namespace ProductsWeb.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductService _service;

        public ProductsController(IMapper mapper, IProductService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _service.GetProducts();
            List<ProductsViewModel> productList = _mapper.Map<List<ProductsViewModel>>(products);
            return View(productList);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Hello = "hello";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, Price, Description, Stock")] CreateProductViewModel products)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<ProductModel>(products);
                await _service.AddProduct(product);
                return View();
            }
            else
            {
                return View();
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int Id, [Bind("Name, Price, Description, Stock")] UpdateProductViewModel product)
        {
            product.Id = Id;

            var updatedProduct = _mapper.Map<ProductModel>(product);
            await _service.UpdateProduct(updatedProduct);

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var product = await _service.GetProductById(Id);
            var mappedProduct = _mapper.Map<CreateProductViewModel>(product);
            return View(mappedProduct);
        }
        public async Task<IActionResult> Delete(int id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteById(int id)
        {
            return View();
        }
    }
}