using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NalaApplication.Models;
using NalaApplication.Repositories;

namespace NalaApplication.Services
{
    public class ProductsService
    {
        private ProductsRepository _rep;
        public ProductsService(ProductsRepository rep)
        {
            _rep = rep;
        }

        internal async Task<ActionResult<List<Product>>> GetProductsAsync()
        {
            var products = await _rep.GetProductsAsync();
            if(products != null)
            {
                return products;
            }
            else
            {
                return new NotFoundResult();
            }
          
        }

        public async Task<ActionResult<List<Product>>> AddProductAsync(Product product)
        {
            if(product != null)
            {
                return await _rep.AddProductAsync(product);
            }
            else
            {
                return new BadRequestResult();
            }
        }

        internal async Task<ActionResult<Product>> GetProductByIdAsync(int id)
        {
            var product = await GetProductByIdAsync(id);
            if(product != null)
            {
                return await _rep.GetProductByIdAsync(id);
            }
            else
            {
                return new NotFoundResult();
            }
           
        }

        internal async Task<ActionResult<List<Product>>> UppdateProductAsync(Product product)
        {
            if(product != null)
            {
                return await _rep.UppdateProductAsync(product);
            }
            else
            {
                return new BadRequestResult();
            }
        }

        internal async Task<ActionResult<List<Product>>> RemoveProductAsync(int id)
        {
            if(id > 0)
            {
                var product = await _rep.GetProductByIdAsync(id);
                if(product != null)
                {
                    return await _rep.RemoveProductAsync(product);
                }
                else
                {
                    return new NotFoundResult();
                }
            }

            return new BadRequestResult();
        }
    }
}
