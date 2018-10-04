using NalaApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NalaApplication.Data
{
    public class DataInitializer
    {
        public static async Task Initializer(AppDbContext context)
        {
            var skirts = new Category { Name = "Skirts" };
            var dress = new Category { Name = "Dresses" };
            var tops = new Category { Name = "Tops" };
            var pants = new Category { Name = "Pants" };

            await context.AddRangeAsync(skirts, dress, tops, pants);
            await context.SaveChangesAsync();

            var p1 = new Product
            {
                Name = "Little black dress",
                Category = dress,
                ImagePath = ".jpg",
                Color = Color.Black,
                Price = 399.90m,
                Size = Size.M,
                Stock = 2,
                PublishDate = DateTime.Today
            };
            var p2 = new Product
            {
                Name = "Little yellow dress",
                Category = dress,
                ImagePath = ".jpg",
                Color = Color.Yellow,
                Price = 399.90m,
                Size = Size.M,
                Stock = 1,
                PublishDate = DateTime.Today
            };

            var p3 = new Product
            {
                Name = "Black top",
                Category = tops,
                ImagePath = ".jpg",
                Color = Color.Black,
                Price = 299m,
                Size = Size.S,
                Stock = 1,
                PublishDate = DateTime.Today
            };

            var p4 = new Product
            {
                Name = "Red top",
                Category = tops,
                ImagePath = ".jpg",
                Color = Color.Red,
                Price = 299m,
                Size = Size.L,
                Stock = 1,
                PublishDate = DateTime.Today
            };

            var p5 = new Product
            {
                Name = "Black skirt",
                Category = skirts,
                ImagePath = ".jpg",
                Color = Color.Black,
                Price = 199m,
                Size = Size.M,
                Stock = 1,
                PublishDate = DateTime.Today
            };
            await context.AddRangeAsync(p1, p2, p3, p4, p5);
            await context.SaveChangesAsync();
        }
    }
}
