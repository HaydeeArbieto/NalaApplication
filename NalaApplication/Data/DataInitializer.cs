using NalaApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NalaApplication.Data
{
    public class DataInitializer
    {
        //populates the in memorydatabase with items
        public static async Task Initializer(AppDbContext context)
        {
            var skirts = new Category { Name = "Skirts" };
            var dress = new Category { Name = "Dresses" };
            var tops = new Category { Name = "Tops" };
            var pants = new Category { Name = "Pants" };

            await context.AddRangeAsync(skirts, dress, tops, pants);
            await context.SaveChangesAsync();


            var black = new Color { Name = "Black" };
            var white = new Color { Name = "White" };
            var grey = new Color { Name = "Grey" };
            var red = new Color { Name = "Red" };
            var blue = new Color { Name = "Blue" };
            var green = new Color { Name = "Green" };
            var pink = new Color { Name = "Pink" };
            var purple = new Color { Name = "Purple" };
            var orange = new Color { Name = "Orange" };
            var yellow = new Color { Name = "Yellow" };
            var brown = new Color { Name = "Brown" };
            var beige = new Color { Name = "Beige" };
            var silver = new Color { Name = "Silver" };
            var gold = new Color { Name = "Gold" };
            var multi = new Color { Name = "Multi" };

            await context.AddRangeAsync(black, white, grey, red, blue, green, pink, purple, orange, yellow, brown, beige, silver, gold, multi);
            await context.SaveChangesAsync();

            var xs = new Size { Name = "XS" };
            var s = new Size { Name = "S" };
            var m = new Size { Name = "M" };
            var l = new Size { Name = "L" };
            var xl = new Size { Name = "XL" };

            await context.AddRangeAsync(xs, s, m, l, xl);
            await context.SaveChangesAsync();

            var p1 = new Product
            {
                Name = "Little black dress",
                Category = dress,
                ImagePath = ".jpg",
                Color = black,
                Price = 399.90m,
                Size = m,
                Stock = 2,
                PublishDate = DateTime.Today
            };
            var p2 = new Product
            {
                Name = "Little yellow dress",
                Category = dress,
                ImagePath = ".jpg",
                Color = yellow,
                Price = 399.90m,
                Size = m,
                Stock = 1,
                PublishDate = DateTime.Today
            };

            var p3 = new Product
            {
                Name = "Black top",
                Category = tops,
                ImagePath = ".jpg",
                Color = black,
                Price = 299m,
                Size = s,
                Stock = 1,
                PublishDate = DateTime.Today
            };

            var p4 = new Product
            {
                Name = "Red top",
                Category = tops,
                ImagePath = ".jpg",
                Color = red,
                Price = 299m,
                Size = l,
                Stock = 1,
                PublishDate = DateTime.Today
            };

            var p5 = new Product
            {
                Name = "Black skirt",
                Category = skirts,
                ImagePath = ".jpg",
                Color = black,
                Price = 199m,
                Size = m,
                Stock = 1,
                PublishDate = DateTime.Today
            };
            await context.AddRangeAsync(p1, p2, p3, p4, p5);
            await context.SaveChangesAsync();
        }
    }
}
