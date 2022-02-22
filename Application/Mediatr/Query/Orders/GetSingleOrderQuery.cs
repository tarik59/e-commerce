using Application.Contracts;
using Application.Services;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediatr.Query.Orders
{

    public class GetSingleOrderQuery : IRequest<OrderDto>
    {
        public int OrderId;
        public int UserId;
        public GetSingleOrderQuery(int userId, int id)
        {
            OrderId = id;
            UserId = userId;
        }
    }

    public class GetSingleOrderHandler : IRequestHandler<GetSingleOrderQuery, OrderDto>
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public GetSingleOrderHandler(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        public async Task<OrderDto> Handle(GetSingleOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderService.GetOrderByIdAsync(request.OrderId);
            if (order.AppUser.Id != request.UserId)
            {
                throw new System.Exception("You are not allowed to see this order");
            }
            return _mapper.Map<OrderDto>(order);
        }
    }
}
