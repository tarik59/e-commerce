using Application.Services;
using EC_Domain.Entity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediatr.Command
{
    public class CreateOrderCommand : IRequest<Unit>
    {
        public int userId;
        public CreateOrderCommand(int Id)
        {
            userId = Id;
        }

    }
    public class UpdateOrderCommand : IRequest<Unit>
    {
        public Order order;
        public UpdateOrderCommand(Order o)
        {
            order = o;  
        }

    }
    public class DeleteOrderCommand : IRequest<Unit>
    {
        public int orderId;
        public DeleteOrderCommand(int id)
        {
            orderId = id;
        }

    }
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
