using Application.Contracts;
using Application.Mediatr.Query;
using Application.Services;
using EC_Domain.Entity;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediatr.Handlers
{
    public class GetAllProductsFromShoppingCartQueryHandler : IRequestHandler<GetAllProductsFromShoppingCartQuery, IEnumerable<ProductDto>>
    {
        private readonly IShoppingCartService _shoppingCartService;

        public GetAllProductsFromShoppingCartQueryHandler(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsFromShoppingCartQuery request, CancellationToken cancellationToken)
        {
            var products =  await _shoppingCartService.GetAllProducts(request.userId);
            return products.Adapt<IEnumerable<ProductDto>>();
        }
    }
}
