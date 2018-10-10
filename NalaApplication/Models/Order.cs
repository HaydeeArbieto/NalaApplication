using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NalaApplication.Models
{
    public class Order
    {
        public int Id { get; set; }

        public Cart Cart { get; set; }

        public DateTime Orderdate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public bool Delivered { get; set; }

        public bool Paid { get; set; }


    }
}
