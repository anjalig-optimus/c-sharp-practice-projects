using Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IItemRepository
    {
         Task<Item> GetByIdAsync(int id);
         Task<IEnumerable<Item>> GetAllAsync();
        Task AddAsync(Item item);
       Task UpdateAsync(Item item);
         Task DeleteAsync(int id);


    }
}
