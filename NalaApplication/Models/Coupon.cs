using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NalaApplication.Models
{
    public class Coupon
    {
        //Code	Coupon type	Coupon amount	Description	Product IDs	Usage / Limit	Expiry date
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public int Usage { get; set; }
        public long Limit  { get; set; }
        public DateTime ExpireDate { get; set; }
        public int CouponTypeId { get; set; }
        public CouponType CouponType { get; set; }
        public List<Product> Products { get; set; }
    }
}
