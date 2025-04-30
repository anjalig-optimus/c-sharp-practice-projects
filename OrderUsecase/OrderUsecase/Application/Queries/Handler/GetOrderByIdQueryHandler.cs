using MediatR;
using Microsoft.EntityFrameworkCore;
namespace OrderUsecase.Application.Queries.Handler
{

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
{
    private readonly IApplicationDbContext _context;

    public GetOrderByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders
            .Include(o => o.OrderItems)
            .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

        if (order == null)
            return null;

        return new OrderDto
        {
            Id = order.Id,
            OrderDate = order.OrderDate,
            OrderItems = order.OrderItems.Select(i => new OrderItemDto
            {
                ProductName = i.ProductName,
                Price = i.Price
            }).ToList()
        };
    }
} 
}

