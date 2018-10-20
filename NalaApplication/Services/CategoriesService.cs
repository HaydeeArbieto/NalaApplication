using Microsoft.AspNetCore.Mvc;
using NalaApplication.Constants;
using NalaApplication.Extensions;
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

        public async Task<ActionResult<List<Category>>> GetAllCategoriesAsync()
        {
            var categories = await _rep.GetAllCategoriesAsync();
            if (categories != null)
            {
                return categories;
            }
            else
            {
                return new NotFoundObjectResult(new { ErrorMessage = ErrorMessages.CategoriesNotFound });
            }
        }

        public async Task<ActionResult<Category>> GetCategoryByIdAsync(int id)
        {
            if(id != 0)
            {
                var categories = await _rep.GetAllCategoriesAsync();
                if(categories != null)
                {
                    return categories.FirstOrDefault(x => x.Id == id);
                }
                else
                {
                    return new NotFoundObjectResult(new { ErrorMessages = ErrorMessages.CategoriesNotFound });
                }
            }
            else
            {
                return new BadRequestObjectResult(new { ErrorMessage = ErrorMessages.IdCantBeZero });
            }
        }

        public async Task<ActionResult<List<Category>>> AddCategoryAsync(string name)
        {
            if(name != null)
            {
                if(await CheckIfCategoryExistsAsync(name))
                {
                    return new BadRequestObjectResult(new { ErrorMessage = ErrorMessages.CategoryAlreadyExists });
                }
                else
                {
                    Category category = CreateCategory(name);
                    return await _rep.AddCategoryAsync(category);
                }
            }
            else
            {
                return new BadRequestObjectResult(new { ErrorMessage = ErrorMessages.CategoryNotFound });
            }
        }

        public async Task<bool> CheckIfCategoryExistsAsync(string name)
        {
            var category = await GetCategoryBySearchAsync(name);
            if (category != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Category> GetCategoryBySearchAsync(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                return null;
            }
            else
            {
                var categories = await _rep.GetAllCategoriesAsync();
                var category = categories.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
                return category;
            }
        }

        public Category CreateCategory(string name)
        {
            return new Category { Name = name.UppercaseFirst() };
        }

        public async Task<ActionResult<List<Category>>> RemoveCategoryAsync(int id)
        {
            if (id != 0)
            {
                return await _rep.RemoveCategoryAsync(id);
            }
            else
            {
                return new BadRequestObjectResult(new { ErrorMessage = ErrorMessages.CategoryNotFound });
            }

        }

        public async Task<ActionResult<List<Category>>> UpdateCategoryAsync(Category category)
        {

            if (category != null)
            {
                return await _rep.UpdateCategoryAsync(category);
            }
            else
            {
                return new BadRequestObjectResult(new { ErrorMessage = ErrorMessages.CategoryNotFound });
            }

        }

    }
}
