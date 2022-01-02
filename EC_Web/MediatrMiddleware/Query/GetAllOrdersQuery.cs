using EC_Domain.Entity;
using MediatR;
using System.Collections.Generic;

namespace EC_Web.MediatrMiddleware.Query
{
    public class GetAllOrdersQuery:IRequest<List<Order>>
    {

    }
}
