using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IJobRequisitionRepository
    {
        Task<JobRequisition> GetByIdAsync(int id);
        Task<IEnumerable<JobRequisition>> GetAllAsync();
        Task AddAsync (JobRequisition jobRequisition);
        Task UpdateAsync (JobRequisition jobRequisition);
        Task DeleteAsync (int id);
    }
}
