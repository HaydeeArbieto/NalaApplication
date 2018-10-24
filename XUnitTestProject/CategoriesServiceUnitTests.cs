using Microsoft.AspNetCore.Mvc;
using NalaApplication.Models;
using NalaApplication.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject
{
    public class CategoriesServiceUnitTests
    {
        public CategoriesService service = new CategoriesService(null);
        [Fact]
        public void Create_Category_Test()
        {

            var result = service.CreateCategory("test");
            var cat = new Category() { Name = "Test" };
            Assert.Equal(cat.Name, result.Name);
        }

        [Fact]
        public async Task Check_If_Category_Exists_False_Test()
        {
            Assert.False(await service.CheckIfCategoryExistsAsync(""));
        }

        [Fact]
        public async Task Check_Return_Null_If_String_Empty_Test()
        {
            Assert.Null(await service.GetCategoryBySearchAsync(""));
        }
    }
}
