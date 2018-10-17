using Microsoft.AspNetCore.Mvc;
using NalaApplication.Services;
using System;
using Xunit;

namespace XUnitTestProject
{
    public class ProductsServiceUnitTests
    {

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
            var result = service.UpdateProductAsync(null).Result;

            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        [Fact]
        public void Remove_A_Product_Test()
        {
            var result = service.RemoveProductAsync(0).Result;

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }


    }
}
