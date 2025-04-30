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
    public class JobRequisitionRepository : IJobRequisitionRepository
    {
        private readonly ApplicationDbContext _context;
        public JobRequisitionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<JobRequisition> GetByIdAsync(int id)
        {
            return await _context.Set<JobRequisition>().Include(j => j.JobRequisitionStatus).FirstOrDefaultAsync(j => j.Id == id);
        }
        public async Task<IEnumerable<JobRequisition>> GetAllAsync()
        {
            return await _context.Set<JobRequisition>().Include(j => j.JobRequisitionStatus).ToListAsync();
        }

        public async Task AddAsync(JobRequisition jobRequisition)
        {
            await _context.Set<JobRequisition>().AddAsync(jobRequisition);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(JobRequisition jobRequisition)
        {
            _context.Set<JobRequisition>().Update(jobRequisition);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity= await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Set<JobRequisition>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
