using BandQ.Commons.Services;
using BandQ.Commons.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BandQ.Services.Services
{
    public class ProductServiceFake : IProductService
    {


        public async Task<ProductModel> AddProduct(ProductModel product)
        {
            return new ProductModel
            {
                 Id = 1,
                Name = "Nail",
                Description = "Small and pointy",
                Price = 0.25m,
                Stock = 1000,
                Weight = 1
            };
        }

        public Task<bool> DeleteProduct(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> GetProductById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductModel>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> UpdateProduct(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
