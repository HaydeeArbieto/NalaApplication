using Microsoft.AspNetCore.Mvc;
using NalaApplication.Constants;
using NalaApplication.Models;
using NalaApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NalaApplication.Services
{
    public class OrdersService
    {
        private readonly OrdersRepository _rep;

        public OrdersService(OrdersRepository rep)
        {
            _rep = rep;
        }

        public async Task<ActionResult<List<Order>>> GetAllOrdersAsync()
        {
            var orders = await _rep.GetOrdersAsync();
            if(orders != null)
            {
                return orders;
            }
            else
            {
                return new NotFoundObjectResult(new { ErrorMessage = ErrorMessages.ObjectsNotFound });
            }
             
        }

        public async Task<ActionResult<Order>> GetOrderByIdAsync(int id)
        {
            if(id != 0)
            {
                var orders = await _rep.GetOrdersAsync();
                if(orders != null)
                {
                    return orders.FirstOrDefault(x => x.Id == id);
                }
                else
                {
                    return new NotFoundObjectResult(new { ErrorMessage = ErrorMessages.ObjectNotFound });
                }
              
            }
            else
            {
                return new BadRequestObjectResult(new { ErrorMessage = ErrorMessages.IdCantBeZero });
            }
         
        }

        public async Task<ActionResult<List<Order>>> UpdateOrderAsync(Order order)
        {
            if(order != null)
            {
                
                return await _rep.UpdateOrderAsync(order);
            }
            else
            {
                return new BadRequestObjectResult(new { ErrorMessage = ErrorMessages.InputEmpty });
            }
        }
    }
}
