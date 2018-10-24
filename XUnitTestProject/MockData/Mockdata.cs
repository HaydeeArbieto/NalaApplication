using NalaApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestProject.MockData
{
    class Mockdata
    {
        public static List<Product> Products = new List<Product>();

        public static void Initialize()
        {
            var skirts = new Category { Name = "Skirts" };
            var dress = new Category { Name = "Dresses" };
            var tops = new Category { Name = "Tops" };
            var pants = new Category { Name = "Pants" };

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

            var xs = new Size { Name = "XS" };
            var s = new Size { Name = "S" };
            var m = new Size { Name = "M" };
            var l = new Size { Name = "L" };
            var xl = new Size { Name = "XL" };


            var p1 = new Product
            {
                Id = 1,
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
                Id = 2,
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
                Id = 3,
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
                Id = 4,
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
                Id = 5,
                Name = "Black skirt",
                Category = skirts,
                ImagePath = ".jpg",
                Color = black,
                Price = 199m,
                Size = m,
                Stock = 1,
                PublishDate = DateTime.Today
            };
            Products.Add(p1);
            Products.Add(p2);
            Products.Add(p3);
            Products.Add(p4);
            Products.Add(p5);
        }
        public static List<Product> GetProducts()
        {
          
            return Products;
        }
    }
}
