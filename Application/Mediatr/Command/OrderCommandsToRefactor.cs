using Application.Contracts;
using Application.Services;
using EC_Domain.Entity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediatr.Command
{

  /*  public class UpdateOrderCommand : IRequest<Unit>
    {
        public OrderDto Order;
        public int UserId;
        public UpdateOrderCommand(int userId, OrderDto o)
        {
            Order = o;  
            UserId = userId;
        }

    }
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, Unit>
    {
        private readonly IOrderService _orderService;
        public UpdateOrderHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            //await _orderService.UpdateOrderAsync(request.order);
            return Unit.Value;
        }
    }*/

}
