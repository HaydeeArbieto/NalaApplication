using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NalaApplication.Models;
using NalaApplication.Services;

namespace NalaApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly CategoriesService _service;

        public CategoriesController(CategoriesService service)
        {
            _service = service;
        }
        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            return await _service.GetAllCategoriesAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<ActionResult<Category>> Get(int id)
        {
            return await _service.GetCategoryByIdAsync(id);
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<List<Category>>> Post([FromBody] Category category)
        {
            return await _service.AddCategoryAsync(category);
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Category>>> Put(int id, [FromBody] Category category)
        {
            if (ModelState.IsValid)
            {
                return await _service.UpdateCategoryAsync(category);
            }

            return NotFound();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        
        public async Task<ActionResult<List<Category>>> Delete(int id)
        {
            return await _service.RemoveCategoryAsync(id);
        }
    }
}
