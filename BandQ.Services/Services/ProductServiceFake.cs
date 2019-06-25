using BandQ.Commons.Services;
using BandQ.Commons.Services.Models;
using ProductsApi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BandQ.Services.Services
{
    public class ProductServiceFake : IProductService
    {

        private readonly Context _context;

        public ProductServiceFake (Context context)
        {
            _context = context;
        }

        public Task<ProductModel> AddProduct()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProduct()
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> GetProductById()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductModel>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> UpdateProduct()
        {
            throw new NotImplementedException();
        }
    }
}
