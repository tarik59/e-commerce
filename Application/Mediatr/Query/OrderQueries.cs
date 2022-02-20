using Application.Services;
using EC_Domain.Entity;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediatr.Query
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<Order>>
    {

    }
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<Order>>
    {
        private readonly IOrderService _orderService;
        public GetAllOrdersHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public Task<IEnumerable<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = _orderService.GetOrdersAsync();
            return orders;
        }
    }

    public class GetSingleOrderQuery : IRequest<Order>
    {
        public int orderId;
        public GetSingleOrderQuery(int id)
        {
            orderId = id;
        }
    }

    public class GetSingleOrderHandler : IRequestHandler<GetSingleOrderQuery, Order>
    {
        private readonly IOrderService _orderService;
        public GetSingleOrderHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public Task<Order> Handle(GetSingleOrderQuery request, CancellationToken cancellationToken)
        {
            var order = _orderService.GetOrderByIdAsync(request.orderId);
            return order;
        }
    }
}
