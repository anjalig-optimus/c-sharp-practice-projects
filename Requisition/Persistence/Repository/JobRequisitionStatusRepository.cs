using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class JobRequisitionStatusRepository : IJobRequisitionStatusRepository
    {
        private readonly ApplicationDbContext _context;
        public JobRequisitionStatusRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<JobRequisitionStatus>> GetAllAsync()
        {
            return await _context.Set<JobRequisitionStatus>().Include(s => s.JobRequisition).ToListAsync();
        }

        public async Task<JobRequisitionStatus> GetByIdAsync(int id)
        {
            return await _context.Set<JobRequisitionStatus>().Include(s => s.JobRequisition).FirstOrDefaultAsync(s => s.JobRequisitionStatusId == id);
        }
        public async Task AddAsync(JobRequisitionStatus jobRequisitionStatus)
        {
            await _context.Set<JobRequisitionStatus>().AddAsync(jobRequisitionStatus);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(JobRequisitionStatus jobRequisitionStatus)
        {
            _context.Set<JobRequisitionStatus>().Update(jobRequisitionStatus);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var entity= await GetByIdAsync(id);
            if (entity != null)
            {
                 _context.Set<JobRequisitionStatus>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
