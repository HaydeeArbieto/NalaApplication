using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NalaApplication.Constants;
using NalaApplication.Models;
using NalaApplication.Repositories;
using NalaApplication.Services;

namespace NalaApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class ProductsController : ControllerBase
    {
        private ProductsService _serv;
        public ProductsController(ProductsService serv)
        {
            _serv = serv;
        }
        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return await _serv.GetProductsAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ActionResult<Product>> Get(int id)
        {
                return await _serv.GetProductByIdAsync(id);
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<List<Product>>> Post([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                return await _serv.AddProductAsync(product);
            }
            else
            {
                return new BadRequestObjectResult(new { ErrorMessage = ErrorMessages.InputIsNotValid});
            }
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Product>>> Put(int id, [FromBody] Product product)
        {
            if(ModelState.IsValid)
            {
                return await _serv.UpdateProductAsync(id, product);
            }

            return NotFound();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Product>>> Delete(int id)
        {
            return await _serv.RemoveProductAsync(id);
        }
    }
}
