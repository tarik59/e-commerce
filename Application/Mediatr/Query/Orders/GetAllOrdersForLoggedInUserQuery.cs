using Application.Contracts;
using Application.Repositories;
using AutoMapper;
using EC_Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediatr.Query.Orders
{
    public class GetAllOrdersForLoggedInUserQuery : IRequest<IEnumerable<OrderDto>>
    {
        public int UserId { get; set; }

        public GetAllOrdersForLoggedInUserQuery(int userId)
        {
            UserId = userId;
        }
    }
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersForLoggedInUserQuery, IEnumerable<OrderDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Order> _orderRepo;
        public GetAllOrdersHandler(IRepository<Order> orderRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<OrderDto>> Handle(GetAllOrdersForLoggedInUserQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepo.GetAll(o => o.userId == request.UserId);
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }
    }

}
