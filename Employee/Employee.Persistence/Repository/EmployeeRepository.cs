using Employee.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Employee.Domain.Entities;
using Employee.Application.Interfaces;

namespace Employee.Persistence.Repository
{
    public class EmployeeRepository(ApplicationDbContext dbContext) : IEmployeeRepository
    {
        public async Task<IEnumerable<Employees>> GetEmployeesAsync()
        {
            return await dbContext.Employees.ToListAsync();
        }
        public async Task<Employees> GetEmployeesByIdAsync(Guid id)
        {
            return await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Employees> AddEmployeesAsync(Employees entity)
        {
            entity.Id=Guid.NewGuid();
            dbContext.Employees.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<Employees> UpdateEmployeesAsync(Guid id ,Employees entity)
        {
            var employee=await dbContext.Employees.FirstOrDefaultAsync(x=>x.Id==id);
            if (employee != null)
            { 
                employee.Name=entity.Name;
                employee.Email=entity.Email;
                employee.Phone_no=entity.Phone_no;
                await dbContext.SaveChangesAsync();
                return employee;
            }
            return entity;
        }
        public async Task<bool> DeleteEmployeesAsync(Guid id)
        {
            var employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee != null)
            {
                dbContext.Employees.Remove(employee);
                await dbContext.SaveChangesAsync();
            }
            return false;
        }
    }
}
