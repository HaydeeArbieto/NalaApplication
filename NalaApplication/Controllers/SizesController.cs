using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NalaApplication.Data;
using NalaApplication.Models;
using NalaApplication.Services;

namespace NalaApplication.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class SizesController : ControllerBase
    {
        private readonly SizesService _service;
        public SizesController(SizesService service)
        {
            _service = service;

        }
        // GET: api/Sizes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Size>>> Get()
        {
            return await _service.GetAllSizesAsync();
        }

        // GET: api/Sizes/5
        [HttpGet("{id}", Name = "GetSize")]
        public async Task<ActionResult<Size>> Get(int id)
        {
            return await _service.GetSizeByIdAsync(id);
        }

        // POST: api/Sizes
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Size>>> Post([FromBody] Size size)
        {
            return await _service.AddSizeAsync(size.Name);
        }

        // PUT: api/Sizes/5
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Size>>> Put(int id, [FromBody] Size Size)
        {
            if (ModelState.IsValid)
            {
                return await _service.UpdateSizeAsync(Size);
            }

            return NotFound();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Size>>> Delete(int id)
        {
            return await _service.RemoveSizeAsync(id);
        }
    }
}