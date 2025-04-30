using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync (int id);
        User ValidateUser (string username, string password);
        Task AddAsync (User user);

    }
}
