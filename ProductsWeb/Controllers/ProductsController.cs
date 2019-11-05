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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name, Price, Description, Stock")] CreateProductViewModel products)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<ProductModel>(products);
                await _service.AddProduct(product);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, [Bind("Name, Price, Description, Stock")] UpdateProductViewModel product)
        {
            product.Id = Id;

            var updatedProduct = _mapper.Map<ProductModel>(product);
            await _service.UpdateProduct(updatedProduct);

            return RedirectToAction("Index");
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
            var product = await _service.GetProductById(id);
            var mappedProduct = _mapper.Map<DeleteProductViewModel>(product);
            return View(mappedProduct);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteById(int id)
        {
            var result = await _service.DeleteProductById(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int id)
        {
            var product = await _service.GetProductById(id);
            var mappedProduct = _mapper.Map<ProductDetailsViewModel>(product);
            return View(mappedProduct);
        }
    }
}