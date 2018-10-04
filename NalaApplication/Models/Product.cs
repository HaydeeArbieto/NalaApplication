using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NalaApplication.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public Size Size { get; set; }

        public Color Color { get; set; }

        public DateTime PublishDate { get; set; }

        public string ImagePath { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

    }

    public enum Color
    {
        None, Black, White, Red, Green, Orange, Yellow, Blue, RoyalBlue, DarkRed, Grey
    }

    public enum Size
    {
        XXS, XS, S, M, L, XL, XXL
    }
}
