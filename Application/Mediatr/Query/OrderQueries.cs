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


    public class GetSingleOrderQuery : IRequest<Order>
    {
        public int orderId;
        public GetSingleOrderQuery(int id)
        {
            orderId = id;
        }
    }
}
