using Application.Contracts;
using EC_Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediatr.Query
{
    public class GetAllProductsFromShoppingCartQuery : IRequest<IEnumerable<ProductDto>>
    {
        public int userId;
        public GetAllProductsFromShoppingCartQuery(int userId)
        {
            this.userId = userId;
        }
    }
}
