using Microsoft.AspNetCore.Mvc;
using NalaApplication.Data;
using NalaApplication.Models;
using NalaApplication.Services;
using System;
using System.Linq;
using Xunit;

namespace XUnitTestProject
{
    public class ProductsServiceUnitTests
    {
        public ProductsServiceUnitTests()
        {
            MockData.Mockdata.Initialize();
        }
        public ProductsService service = new ProductsService(null);
        [Fact]
        public void Get_A_ProductByProductId_Test()
        {
             
            var result = service.GetProductByIdAsync(0).Result;

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void Add_A_Product_Test()
        {
            var result = service.AddProductAsync(null).Result;

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void Update_A_Product_Test()
        {
            var result = service.UpdateProductAsync(0, null).Result;

            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        [Fact]
        public void Remove_A_Product_Test()
        {
            var result = service.RemoveProductAsync(0).Result;

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void Update_Product_Properties()
        {
            var newProduct = new Product() { Price = 499m , Stock = 1, Name = "Dress"};
            var oldProduct = MockData.Mockdata.GetProducts().FirstOrDefault(x=>x.Id == 1);

            var p = service.UpdateProductsProperties(oldProduct, newProduct);
            Assert.Equal(499m, p.Price);
            Assert.Equal(1, p.Stock);
            Assert.Equal("Dress", p.Name);
            Assert.Equal(".jpg", p.ImagePath);
        }


    }
}
