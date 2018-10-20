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
        //Gets all categories
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }
        //Add category to database, returns all categories
        public async Task<List<Category>> AddCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return await GetAllCategoriesAsync();
        }
        //Remove category from database by it´s id, returns all categoris
        public async Task<List<Category>> RemoveCategoryAsync(int id)
        {
            var category = await GetCategoryById(id);
             _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return await GetAllCategoriesAsync();

        }
        //Updates a category in the database, returns alla categories
        public async Task<List<Category>> UpdateCategoryAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return await GetAllCategoriesAsync();

        }
        //Gets a category by it´s id
        public async Task<Category> GetCategoryById(int id)
        {
            var categories = await GetAllCategoriesAsync();
            return categories.FirstOrDefault(x => x.Id == id);
        }
    }
}
