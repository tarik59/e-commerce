using Application.Mediatr.Command;
using Application.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediatr.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Unit>
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
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, Unit>
    {
        private readonly IOrderService _orderService;
        public UpdateOrderHandler(IOrderService orderService)  
        {
            _orderService = orderService;
        }
        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            await _orderService.UpdateOrderAsync(request.order);
            return Unit.Value;
        }
    }
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, Unit>
    {
        private readonly IOrderService _orderService;
        public DeleteOrderHandler(IOrderService orderService)  
        {
            _orderService = orderService;
        }
        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            await _orderService.DeleteOrderAsync(request.orderId);
            return Unit.Value;
        }
    }
}
