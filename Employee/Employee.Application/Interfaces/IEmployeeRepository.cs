using Employee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employees>> GetEmployeesAsync();
        Task<Employees> GetEmployeesByIdAsync(Guid id);
        Task<Employees> AddEmployeesAsync(Employees entity);
        Task<Employees> UpdateEmployeesAsync(Guid id ,Employees entity);
        Task<bool> DeleteEmployeesAsync(Guid id);
    }
}
