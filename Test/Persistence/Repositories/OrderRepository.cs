using Application.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Order order)
        {
            await _context.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
           return await _context.Orders.Include(o => o.OrderItems).ToListAsync();
           // return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
             return await _context.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Item).FirstOrDefaultAsync(o=>o.Id == id);
          //  return await _context.Orders.FirstOrDefault(id);
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}
