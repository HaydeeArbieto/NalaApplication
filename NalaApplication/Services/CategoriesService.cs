using NalaApplication.Models;
using NalaApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NalaApplication.Services
{
    public class CategoriesService
    {
        private CategoriesRepository _rep;
        public CategoriesService(CategoriesRepository rep)
        {
            _rep = rep;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var categories = await _rep.GetAllCategoriesAsync();
            return categories.FirstOrDefault(x => x.Id == id);
        }
    }
}
