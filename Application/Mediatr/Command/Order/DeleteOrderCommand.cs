using Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediatr.Command.Order
{
    public class DeleteOrderCommand : IRequest<Unit>
    {
        public int orderId { get; }
        public DeleteOrderCommand(int id)
        {
            orderId = id;
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
