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
    public class CreateOrderCommand : IRequest<Unit>
    {
        public int userId { get; }
        public CreateOrderCommand(int Id)
        {
            userId = Id;
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

}
