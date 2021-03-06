﻿using Microsoft.AspNetCore.Mvc;
using NalaApplication.Constants;
using NalaApplication.Extensions;
using NalaApplication.InterFaces;
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
      
        private readonly IGenericRepository<Category> _rep;
        public CategoriesService(IGenericRepository<Category> rep)
        {
            _rep = rep;
        }

        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategoriesAsync()
        {
            var categories = await _rep.FindAllAsync();
            if (categories != null)
            {
                return categories.ToList();
            }
            else
            {
                return new NotFoundObjectResult(new { ErrorMessage = ErrorMessages.ObjectsNotFound });
            }
        }

        public async Task<ActionResult<Category>> GetCategoryByIdAsync(int id)
        {
            if(id != 0)
            {
                var categories = await _rep.FindAllAsync();
                if(categories != null)
                {
                    return categories.FirstOrDefault(x => x.Id == id);
                }
                else
                {
                    return new NotFoundObjectResult(new { ErrorMessages = ErrorMessages.ObjectNotFound });
                }
            }
            else
            {
                return new BadRequestObjectResult(new { ErrorMessage = ErrorMessages.IdCantBeZero });
            }
        }

        public async Task<ActionResult<IEnumerable<Category>>> AddCategoryAsync(string name)
        {
            if(name != null)
            {
                if(await CheckIfCategoryExistsAsync(name))
                {
                    return new BadRequestObjectResult(new { ErrorMessage = ErrorMessages.ObjectAlreadyExists });
                }
                else
                {
                    Category category = CreateCategory(name);
                     _rep.Create(category);
                    await _rep.SaveAsync();
                    return new OkObjectResult(await _rep.FindAllAsync()); 
                }
            }
            else
            {
                return new BadRequestObjectResult(new { ErrorMessage = ErrorMessages.ObjectNotFound });
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
                var categories = await _rep.FindAllAsync();
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
                var category = GetCategoryByIdAsync(id).Result;
                 _rep.Delete(category.Value);
                await _rep.SaveAsync();
                return new OkObjectResult(await _rep.FindAllAsync());
            }
            else
            {
                return new BadRequestObjectResult(new { ErrorMessage = ErrorMessages.ObjectNotFound });
            }

        }

        public async Task<ActionResult<List<Category>>> UpdateCategoryAsync(Category category)
        {

            if (category != null)
            {
                  _rep.Update(category);
                await _rep.SaveAsync();
                return new OkObjectResult(await _rep.FindAllAsync());
            }
            else
            {
                return new BadRequestObjectResult(new { ErrorMessage = ErrorMessages.ObjectNotFound });
            }

        }

    }
}
