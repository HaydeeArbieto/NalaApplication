using Microsoft.EntityFrameworkCore;
using NalaApplication.Data;
using NalaApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NalaApplication.Repositories
{
    public class ProductRepository
    {
        private AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync(); 
        }

       
    }
}
