using EC_Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediatr.Query
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {

    }


    public class GetSingleProductQuery : IRequest<Product>
    {
        public int ProductId;
        public GetSingleProductQuery(int id)
        {
            ProductId = id;
        }
    }
}
