using WebAPIUsecase.Core.Entities;

namespace WebAPIUsecase.Infrastructure.Data
{
    public interface InMemoryOrderRepository:IOrderRepository
    {
        private readonly List<Order> _orders = new List<Order>();

        public Task<List<Order>> GetOrdersAsync() => Task.FromResult(_orders);

        public Task<Order> GetOrderByIdAsync(int orderId) =>
            Task.FromResult(_orders.FirstOrDefault(o => o.Id == orderId));

        public Task AddOrderAsync(Order order)
        {
            order.Id = _orders.Count + 1;
            _orders.Add(order);
            return Task.CompletedTask;
        }
    }
}
