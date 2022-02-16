using Application.Mediatr.Query;
using Application.Services;
using EC_Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediatr.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductService _productService;
        public GetAllProductsHandler(IProductService productService)
        {
            _productService = productService;
        }
        public Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var orders = _productService.GetProductsAsync();
            return orders;
        }
    }
}
