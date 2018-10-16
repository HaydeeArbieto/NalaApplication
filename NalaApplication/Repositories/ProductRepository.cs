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

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Product>> RemoveProductAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return await GetProductsAsync();
        }

        public async Task<List<Product>> AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return await GetProductsAsync();
        }

        public async Task<List<Product>> UpdateProductAsync(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return await GetProductsAsync();
        }


    }
}
