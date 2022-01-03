using EC_Domain.Entity;
using EC_Services.Interfaces;
using EC_Web.MediatrMiddleware.Command;
using EC_Web.MediatrMiddleware.Query;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EC_Web.MediatrMiddleware.Handlers
{
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

    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand,Unit>
    {
        private readonly IOrderService _orderService;
        public CreateOrderHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
             await _orderService.CreateOrder(request.userId);
            return Unit.Value;
        }
    }



}
