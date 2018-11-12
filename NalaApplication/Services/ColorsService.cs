using Microsoft.AspNetCore.Mvc;
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
    public class ColorsService
    {
        private readonly IGenericRepository<Color> _rep;
        public ColorsService(IGenericRepository<Color> rep)
        {
            _rep = rep;
        }

        public async Task<ActionResult<IEnumerable<Color>>> GetAllColorsAsync()
        {
            var colors = await _rep.FindAllAsync();
            if (colors != null)
            {
                return colors.ToList();
            }
            else
            {
                return new NotFoundObjectResult(new { ErrorMessage = ErrorMessages.ObjectsNotFound });
            }
        }

        public async Task<ActionResult<Color>> GetColorByIdAsync(int id)
        {
            if (id != 0)
            {
                var colors = await _rep.FindAllAsync();
                if (colors != null)
                {
                    return colors.FirstOrDefault(x => x.Id == id);
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

        public async Task<ActionResult<IEnumerable<Color>>> AddColorAsync(string name)
        {
            if (name != null)
            {
                if (await CheckIfColorExistsAsync(name))
                {
                    return new BadRequestObjectResult(new { ErrorMessage = ErrorMessages.ObjectAlreadyExists });
                }
                else
                {
                    Color color = CreateColor(name);
                    _rep.Create(color);
                    await _rep.SaveAsync();
                    return new OkObjectResult(await _rep.FindAllAsync());
                }
            }
            else
            {
                return new BadRequestObjectResult(new { ErrorMessage = ErrorMessages.ObjectNotFound });
            }
        }

        public async Task<bool> CheckIfColorExistsAsync(string name)
        {
            var color = await GetColorBySearchAsync(name);
            if (color != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Color> GetColorBySearchAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }
            else
            {
                var colors = await _rep.FindAllAsync();
                var color = colors.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
                return color;
            }
        }

        public Color CreateColor(string name)
        {
            return new Color { Name = name.UppercaseFirst() };
        }

        public async Task<ActionResult<List<Color>>> RemoveColorAsync(int id)
        {
            if (id != 0)
            {
                var color = GetColorByIdAsync(id).Result;
                _rep.Delete(color.Value);
                await _rep.SaveAsync();
                return new OkObjectResult(await _rep.FindAllAsync());
            }
            else
            {
                return new BadRequestObjectResult(new { ErrorMessage = ErrorMessages.ObjectNotFound });
            }

        }

        public async Task<ActionResult<List<Color>>> UpdateColorAsync(Color color)
        {

            if (color != null)
            {
                _rep.Update(color);
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
