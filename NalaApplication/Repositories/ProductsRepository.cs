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
        //Get all products includes products category and size
        public async Task<List<Product>> GetProductsAsync()
        {
            var products = await _context.Products.Include(x=>x.Size).Include(x=>x.Color).Include(x=>x.Category).ToListAsync();
            return products;
        }
        //Remove product from database, return all products
        public async Task<List<Product>> RemoveProductAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return await GetProductsAsync();
        }
        //Add product in database, returns all products
        public async Task<List<Product>> AddProductAsync(Product product)
        {
             _context.Entry(product).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return await GetProductsAsync();
        }
        //Get a product by it´s id
        public async Task<Product> GetProductByIdAsync(int id)
        {
            var products = await GetProductsAsync();
            return  products.FirstOrDefault(x => x.Id == id);
        }

        //Update a product in the database, returns all products
        public async Task<List<Product>> UpdateProductAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return await GetProductsAsync();
        }



    }
}
