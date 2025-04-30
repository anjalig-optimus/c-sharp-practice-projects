using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IJobRequisitionStatusRepository
    {
        Task<JobRequisitionStatus> GetByIdAsync (int id);
        Task<IEnumerable<JobRequisitionStatus>> GetAllAsync ();
        Task AddAsync (JobRequisitionStatus jobRequisitionStatus);
        Task UpdateAsync (JobRequisitionStatus jobRequisitionStatus);
        Task DeleteAsync (int id);
    }
}
