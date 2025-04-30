
using WebAPIUsecase.Core.Entities;
using WebAPIUsecase.Infrastructure.Data;

namespace WebAPIUsecase.Application.Commands
{
    public class CreateOrderCommand 
    {
        public int CustomerId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }

    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class CreateOrderCommandHandler 
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                CustomerId = request.CustomerId,
                OrderDate = DateTime.UtcNow
            };

            foreach (var item in request.OrderItems)
            {
                var product = await _productRepository.GetProductByIdAsync(item.ProductId);
                if (product == null) throw new Exception("Product not found");

                order.OrderItems.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Product = product
                });
            }

            await _orderRepository.AddOrderAsync(order);
            return order.Id;
        }
    }
}