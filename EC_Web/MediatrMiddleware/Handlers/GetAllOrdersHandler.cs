using EC_Domain.Entity;
using EC_Services.Interfaces;
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
        public  Task<IEnumerable<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders =  _orderService.GetOrdersAsync();
            return orders;
        }
    }
}
