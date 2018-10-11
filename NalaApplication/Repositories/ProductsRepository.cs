using Microsoft.EntityFrameworkCore;
using NalaApplication.Data;
using NalaApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NalaApplication.Repositories
{
    public class ProductsRepository
    {
        private AppDbContext _context;
        public ProductsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync(); 
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

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var products = await GetProductsAsync();
            return  products.FirstOrDefault(x => x.Id == id);
        }

        public async Task<List<Product>> UppdateProductAsync(Product product)
        {
             _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return await GetProductsAsync();
        }



    }
}
