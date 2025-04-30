using MediatR;

namespace OrderUsecase.Application.Commands
{
    public class CreateOrderCommand:IRequest<int>
    {
        public int CustomerId { get; set; }
        public List<CreateOrderItemDto> OrderItems { get; set; }
    }
    public class CreateOrderItemDto
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
