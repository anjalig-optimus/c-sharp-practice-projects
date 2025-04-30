using WebAPIUsecase.Core.Entities;

namespace WebAPIUsecase.Infrastructure.Data
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrdersAsync();
        Task<Order> GetOrderByIdAsync(int orderId);
        Task AddOrderAsync(Order order);
    }
}
