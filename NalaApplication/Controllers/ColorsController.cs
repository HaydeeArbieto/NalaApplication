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
    public class ColorsController : ControllerBase
    {
        private readonly ColorsService _service;
        public ColorsController(ColorsService service)
        {
            _service = service;

        }
        // GET: api/Colors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Color>>> Get()
        {
            return await _service.GetAllColorsAsync();
        }

        // GET: api/Colors/5
        [HttpGet("{id}", Name = "GetColor")]
        public async Task<ActionResult<Color>> Get(int id)
        {
            return await _service.GetColorByIdAsync(id);
        }

        // POST: api/Colors
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Color>>> Post([FromBody] Color color)
        {
            return await _service.AddColorAsync(color.Name);
        }

        // PUT: api/Colors/5
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Color>>> Put(int id, [FromBody] Color Color)
        {
            if (ModelState.IsValid)
            {
                return await _service.UpdateColorAsync(Color);
            }

            return NotFound();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Color>>> Delete(int id)
        {
            return await _service.RemoveColorAsync(id);
        }
    }
}