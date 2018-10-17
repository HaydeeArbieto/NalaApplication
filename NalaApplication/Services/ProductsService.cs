
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NalaApplication.Constants;
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

         
        public async Task<ActionResult<List<Product>>> GetProductsAsync()
        {
            var products = await _rep.GetProductsAsync();
            if(products != null)
            {
                return products;
            }
            else
            {
                return new NotFoundObjectResult(new { ErrorMessage = ErrorMessages.ProductsNotFound });
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
                return new BadRequestObjectResult(new { ErrorMessage = ErrorMessages.ProductNotNull });
            }
        }

        public async Task<ActionResult<Product>> GetProductByIdAsync(int id)
        {
            if(id != 0)
            {
                var product = await GetProductByIdAsync(id);
                if (product != null)
                {
                    return await _rep.GetProductByIdAsync(id);
                }
                else
                {
                    return new NotFoundObjectResult(new { ErrorMessage = ErrorMessages.IdCantBeZero});
                } 
            }
            else
            {
                return new BadRequestObjectResult(new { ErrorMessage = ErrorMessages.IdCantBeZero });
            }
           
        }

        public async Task<ActionResult<List<Product>>> UpdateProductAsync(Product product)
        {
            if(product != null)
            {
                return await _rep.UpdateProductAsync(product);
            }
            else
            {
                return new NotFoundObjectResult(new { ErrorMessage = ErrorMessages.ProductNotNull });
            }
        }

        public async Task<ActionResult<List<Product>>> RemoveProductAsync(int id)
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
                    return  new NotFoundObjectResult(new { ErrorMessage = ErrorMessages.ProductNotFound });
                }
            }

            return new BadRequestObjectResult(new { ErrorMessage = ErrorMessages.IdCantBeZero });
        }
    }
}
