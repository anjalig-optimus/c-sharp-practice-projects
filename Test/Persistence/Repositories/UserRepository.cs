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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.Include(o => o.Orders).FirstOrDefaultAsync(o => o.Id == id);
        }

        public User ValidateUser(string username, string password)
        {
            return _context.Users.SingleOrDefault(u => u.Username ==username && u.Password ==password);
        }
    }
}
