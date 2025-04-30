using OrderUsecase.Core.Entities;
using MediatR;

namespace OrderUsecase.Application.Commands.Handlers
{
    public class CreateOrderCommandHandler: IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateOrderCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var order = new Order
                {
                    CustomerId = request.CustomerId,
                    OrderDate = DateTime.UtcNow,
                    OrderItems = request.OrderItems.Select(item => new OrderItem
                    {
                        ProductName = item.ProductName,
                        Price = item.Price
                    }).ToList()
                };



                _context.Orders.Add(order);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex) { 
            
                Console.WriteLine(ex.ToString());
            
            }


            

            return 1;
        }
    }
}
