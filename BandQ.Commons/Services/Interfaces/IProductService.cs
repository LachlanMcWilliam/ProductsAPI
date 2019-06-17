using BandQ.Commons.Services.Models;
using BandQ.Data.Classes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BandQ.Commons.Services
{
    /// <summary>
    /// Provides crude opperations for Products in the database
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Get Product List from Database
        /// </summary>
        /// <returns>
        /// List of Products
        /// </returns>
        Task<List<ProductModel>>GetProducts();
        /// <summary>
        /// Update product specified by its id
        /// </summary>
        /// <returns>
        /// ProductModel
        /// </returns>
        Task<ProductModel> UpdateProduct();
        /// <summary>
        /// Delete product specified by its id
        /// </summary>
        /// <returns>
        /// Boolean
        /// </returns>
        Task<bool> DeleteProduct();
        /// <summary>
        /// Adds a ProductModel to the Database
        /// </summary>
        /// <returns>
        /// ProductModel
        /// </returns>
        Task<ProductModel> AddProduct();
        /// <summary>
        /// Gets a Product form the Database by searching for the Id
        /// </summary>
        /// <returns>
        /// ProductModel
        /// </returns>
        Task<ProductModel> GetProductById();
        
    }
}
