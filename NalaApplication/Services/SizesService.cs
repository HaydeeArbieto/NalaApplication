using Microsoft.AspNetCore.Mvc;
using NalaApplication.Constants;
using NalaApplication.Extensions;
using NalaApplication.InterFaces;
using NalaApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NalaApplication.Services
{
    public class SizesService
    {
        private readonly IGenericRepository<Size> _rep;
        public SizesService(IGenericRepository<Size> rep)
        {
            _rep = rep;
        }

        public async Task<ActionResult<IEnumerable<Size>>> GetAllSizesAsync()
        {
            var sizes = await _rep.FindAllAsync();
            if (sizes != null)
            {
                return sizes.ToList();
            }
            else
            {
                return new NotFoundObjectResult(new { ErrorMessage = ErrorMessages.ObjectsNotFound });
            }
        }

        public async Task<ActionResult<Size>> GetSizeByIdAsync(int id)
        {
            if (id != 0)
            {
                var sizes = await _rep.FindAllAsync();
                if (sizes != null)
                {
                    return sizes.FirstOrDefault(x => x.Id == id);
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

        public async Task<ActionResult<IEnumerable<Size>>> AddSizeAsync(string name)
        {
            if (name != null)
            {
                if (await CheckIfSizeExistsAsync(name))
                {
                    return new BadRequestObjectResult(new { ErrorMessage = ErrorMessages.ObjectAlreadyExists });
                }
                else
                {
                    Size size = CreateSize(name);
                    _rep.Create(size);
                    await _rep.SaveAsync();
                    return new OkObjectResult(await _rep.FindAllAsync());
                }
            }
            else
            {
                return new BadRequestObjectResult(new { ErrorMessage = ErrorMessages.ObjectNotFound });
            }
        }

        public async Task<bool> CheckIfSizeExistsAsync(string name)
        {
            var size = await GetSizeBySearchAsync(name);
            if (size != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Size> GetSizeBySearchAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }
            else
            {
                var sizes = await _rep.FindAllAsync();
                var size = sizes.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
                return size;
            }
        }

        public Size CreateSize(string name)
        {
            return new Size { Name = name.UppercaseFirst() };
        }

        public async Task<ActionResult<List<Size>>> RemoveSizeAsync(int id)
        {
            if (id != 0)
            {
                var size = GetSizeByIdAsync(id).Result;
                _rep.Delete(size.Value);
                await _rep.SaveAsync();
                return new OkObjectResult(await _rep.FindAllAsync());
            }
            else
            {
                return new BadRequestObjectResult(new { ErrorMessage = ErrorMessages.ObjectNotFound });
            }

        }

        public async Task<ActionResult<List<Size>>> UpdateSizeAsync(Size size)
        {

            if (size != null)
            {
                _rep.Update(size);
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
