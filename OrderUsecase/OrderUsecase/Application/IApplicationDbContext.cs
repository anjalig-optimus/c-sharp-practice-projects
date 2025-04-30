using Microsoft.EntityFrameworkCore;
using OrderUsecase.Core.Entities;
using System.Collections.Generic;

namespace OrderUsecase.Application
{
    public interface IApplicationDbContext 
    {
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<Customer> Customers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
