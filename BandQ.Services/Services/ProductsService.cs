using BandQ.Commons.DAL.Interfaces;
using BandQ.Commons.Services;
using BandQ.Commons.Services.Models;
using BandQ.Data.Classes;
using BandQ.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace BandQ.Services.Services
{
    public class ProductsService : IProductService
    {
        private IGenericRepository _productRepository;

        public ProductsService(IGenericRepository ProductsRepository)
        {
            _productRepository = ProductsRepository;
        }
        
        public async Task<ProductModel> AddProduct(ProductModel product)
        {
            var productModel = await _productRepository.AddAsync<Product>(new Product {
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                Weight = product.Weight
            });
            //await _productRepository.CommitAsync();
            return new ProductModel {
                Id = productModel.Id,
                Description = productModel.Description,
                Name = productModel.Name,
                Price = productModel.Price,
                Stock = productModel.Stock,
                Weight = productModel.Weight
            };
        }

        public async Task<bool> DeleteProduct(ProductModel product)
        {
            Product productEntity = await _productRepository.GetSingleAsync<Product>(x => x.Id == product.Id);
            _productRepository.Delete<Product>(productEntity);
            await _productRepository.CommitAsync();

            return true;
        }

        public async Task<bool> DeleteProductById(int id)
        {
            Product productEntity = await _productRepository.GetSingleAsync<Product>(x => x.Id == id);
            _productRepository.Delete<Product>(productEntity);
            await _productRepository.CommitAsync();

            return true;
        }

        public async Task<ProductModel> GetProductById(int Id)
        {
            try
            {
                Product product = await _productRepository.GetSingleAsync<Product>(x => x.Id == Id);
                return new ProductModel
                {
                    Description = product.Description,
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Stock = product.Stock,
                    Weight = product.Weight
                };
            }
            catch(ProductServiceException ex){
                throw new ProductServiceException("The product couldn't be retrieved from the database", ex);
            }
        }

        public async Task<List<ProductModel>> GetProducts()
        {
            var products = _productRepository.AllIncluding<Product>();

            var productsModel = products.Select(product => new ProductModel {
                Description = product.Description,
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                Weight = product.Weight,
            }).ToList();


            return productsModel;
        }

        public async Task<ProductModel> UpdateProduct(ProductModel product)
        {
            var productEntity = await _productRepository.GetSingleAsync<Product>(x => x.Id == product.Id);

            productEntity.Name = product.Name;
            productEntity.Price = product.Price;
            productEntity.Stock = product.Stock;
            productEntity.Description = product.Description;

            await _productRepository.CommitAsync();
                
           return product;
        }
    }
}
