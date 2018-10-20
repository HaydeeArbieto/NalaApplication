using Microsoft.EntityFrameworkCore;
using NalaApplication.Data;
using NalaApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NalaApplication.Repositories
{
    public class OrdersRepository
    {
        private AppDbContext _context;

        public OrdersRepository(AppDbContext context)
        {
            _context = context;
        }

        //Get all orders
        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }
        //Add order to database, returns all orders
        public async Task<List<Order>> AddOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return await GetOrdersAsync();

        }
    }
}
