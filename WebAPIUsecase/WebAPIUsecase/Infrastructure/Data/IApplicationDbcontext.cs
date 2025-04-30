using System.Collections.Generic;
using WebAPIUsecase.Core.Entities;

namespace WebAPIUsecase.Infrastructure.Data
{
    public interface IApplicationDbcontext
    {
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<Customer> Customers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
