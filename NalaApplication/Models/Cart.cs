using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NalaApplication.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public List<CartItem> CartItems { get; set; }

        public Order Order { get; set; }

        public int NumberOfProducts => CartItems.Count();

        public decimal TotalPrice { get; set; }
    }
}
