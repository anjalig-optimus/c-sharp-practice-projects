using Application.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _context;
        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Item item)
        {
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            _context.Items.Remove(await _context.Items.FindAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            var result = await _context.Items.ToListAsync();
           //var result = await _context.Items.Include(I =>I.OrderItems).ToListAsync();
           return result;
        }

        public async Task<Item> GetByIdAsync(int id)
        {
           return await _context.Items.FindAsync(id);
        }

        public async Task UpdateAsync(Item item)
        {
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
