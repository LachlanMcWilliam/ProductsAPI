using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductsWeb.Models;

namespace ProductsWeb.Controllers
{
    public class ProductsController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ProductsViewModel> productList = new List<ProductsViewModel> {
                 new ProductsViewModel
                 {
                      Description = "Comes in bars",
                        Name = "Steel",
                         Price = 25,
                          Stock = 400,
                           Id = 1
                 },
                 new ProductsViewModel
                 {
                      Description = "Comes in planks",
                        Name = "Wood",
                         Price = 15,
                          Stock = 600,
                           Id = 2
                 },
                 new ProductsViewModel
                 {
                      Description = "Comes in bags",
                        Name = "Soil",
                         Price = 5,
                          Stock = 1500,
                           Id = 3
                 },
                 new ProductsViewModel
                 {
                      Description = "Heavy",
                        Name = "Rock",
                         Price = 7,
                          Stock = 400,
                           Id = 4
                 }
            };
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
                return View();
            }
            else
            {
                return View();
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Name, Price, Description, Stock")] CreateProductViewModel product)
        {
            return View();
        }
        public async Task<IActionResult> Edit()
        {
            return View();
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