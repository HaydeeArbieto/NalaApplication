using NalaApplication.Data;
using NalaApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NalaApplication.Repositories
{
    public class CategoriesRepository
    {
        private AppDbContext _context;
        public CategoriesRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }
        public async Task<List<Category>> AddCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return await GetAllCategoriesAsync();
        }

        public async Task<List<Category>> RemoveCategoryAsync(int id)
        {
            var category = await GetCategoryById(id);
             _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return await GetAllCategoriesAsync();

        }

        public async Task<List<Category>> UpdateCategoryAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return await GetAllCategoriesAsync();

        }

        public async Task<Category> GetCategoryById(int id)
        {
            var categories = await GetAllCategoriesAsync();
            return categories.FirstOrDefault(x => x.Id == id);
        }
    }
}
