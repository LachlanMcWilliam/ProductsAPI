using BandQ.Commons.Services;
using BandQ.Commons.Services.Models;
using BandQ.Services.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BandQ.Test
{
    public class ProductServiceTest
    {
        private IProductService _service;

        public ProductServiceTest()
        {
            _service = new ProductServiceFake();
        }

        [Fact]
        public async Task WhenAProductIsAddedAnIdWillBeReturned()
        {
            //Arrange
            var product = new ProductModel
            {
                Name = "Nail",
                Description = "Small and pointy",
                Price = 0.25m,
                Stock = 1000,
                Weight = 1
            };
            //Act
            var result = await this._service.AddProduct(product);
            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.Name, product.Name);
            Assert.True(result.Id > 0);
        }

        [Fact]
        public async Task WhenAProductIsAddedAnIdWillBeReturnedMock()
        {
            //Arrange
            var product = new ProductModel
            {
                Name = "Nail",
                Description = "Small and pointy",
                Price = 0.25m,
                Stock = 1000,
                Weight = 1
            };

            Mock<IProductService> MockService = new Mock<IProductService>();

            MockService.Setup(x => x.AddProduct(product)).ReturnsAsync(new ProductModel
            {
                Name = "Nail",
                Description = "Small and pointy",
                Price = 0.25m,
                Stock = 1000,
                Weight = 1,
                Id = 1

            });
            //Act
            var result = await MockService.Object.AddProduct(product);
            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.Name, product.Name);
            Assert.True(result.Id > 0);
        }
    }
}
