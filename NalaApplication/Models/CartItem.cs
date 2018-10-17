using System;
using System.ComponentModel.DataAnnotations;

namespace NalaApplication.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
    }
}