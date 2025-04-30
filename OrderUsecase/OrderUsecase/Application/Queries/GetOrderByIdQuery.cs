using MediatR;

namespace OrderUsecase.Application.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderDto>
    {
        public int Id { get; set; }
    }
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }

    public class OrderItemDto
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
