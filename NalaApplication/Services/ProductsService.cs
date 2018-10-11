using NalaApplication.Models;
using NalaApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NalaApplication.Services
{
    public class ProductsService
    {
        private ProductsRepository _rep;
        public ProductsService(ProductsRepository rep)
        {
            _rep = rep;
        }

      
        public async Task<Product> GetProductByIdAsync(int id)
        {
            var products = await _rep.GetProductsAsync();
            return products.FirstOrDefault(x => x.Id == id);
        }
    }
}
