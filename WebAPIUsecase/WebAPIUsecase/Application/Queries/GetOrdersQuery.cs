using WebAPIUsecase.Core.Entities;
using WebAPIUsecase.Infrastructure.Data;

namespace WebAPIUsecase.Application.Queries
{
    public class GetOrdersQuery
    {
    }
        public class GetOrdersQueryHandler
        {
            private readonly IOrderRepository _orderRepository;

            public GetOrdersQueryHandler(IOrderRepository orderRepository)
            {
                _orderRepository = orderRepository;
            }

            public async Task<List<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
            {
                return await _orderRepository.GetOrdersAsync();
            }
        }
    }
