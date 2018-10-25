
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
                return new NotFoundObjectResult(new { ErrorMessage = ErrorMessages.ObjectsNotFound });
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
                return new BadRequestObjectResult(new { ErrorMessage = ErrorMessages.ObjectNotFound });
            }
        }

        public async Task<ActionResult<Product>> GetProductByIdAsync(int id)
        {
            if(id != 0)
            {
                var product = await _rep.GetProductByIdAsync(id);
                if (product != null)
                {
                    return product;
                }
                else
                {
                    return new NotFoundObjectResult(new { ErrorMessage = ErrorMessages.ObjectNotFound});
                } 
            }
            else
            {
                return new BadRequestObjectResult(new { ErrorMessage = ErrorMessages.IdCantBeZero });
            }
           
        }

        public async Task<ActionResult<List<Product>>> UpdateProductAsync(int id, Product product)
        {
            if(id != 0)
            {
                var oldProduct = await _rep.GetProductByIdAsync(id);
                if(oldProduct != null)
                {
                    Product updatedProduct = UpdateProductsProperties(oldProduct, product);
                  

                    return await _rep.UpdateProductAsync(updatedProduct);
                }
                else
                {
                    return new NotFoundObjectResult(new { ErrorMessage = ErrorMessages.ObjectNotFound });
                }
               
            }
            else
            {
                return new NotFoundObjectResult(new { ErrorMessage = ErrorMessages.IdCantBeZero });
            }
        }

        public Product UpdateProductsProperties(Product oldProduct, Product product)
        {
            var oldProps = oldProduct.GetType().GetProperties().ToList();
            var newProps = product.GetType().GetProperties().ToList();

            for (int i = 1; i < newProps.Count; i++)
            {
                var oldValue = oldProps[i].GetValue(oldProduct);
                var newValue = newProps[i].GetValue(product);

                if(newValue != null && newValue != oldValue)
                {
                    oldProps[i].SetValue(oldProduct, newValue);
                }
            }
            return oldProduct;
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
                    return  new NotFoundObjectResult(new { ErrorMessage = ErrorMessages.ObjectNotFound });
                }
            }

            return new BadRequestObjectResult(new { ErrorMessage = ErrorMessages.IdCantBeZero });
        }
    }
}
