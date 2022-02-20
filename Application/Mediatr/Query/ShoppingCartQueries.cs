using Application.Contracts;
using Application.Services;
using AutoMapper;
using EC_Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    public class GetAllProductsFromShoppingCartQueryHandler : IRequestHandler<GetAllProductsFromShoppingCartQuery, IEnumerable<ProductDto>>
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IMapper _mapper;

        public GetAllProductsFromShoppingCartQueryHandler(IShoppingCartService shoppingCartService, IMapper mapper)
        {
            _shoppingCartService = shoppingCartService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsFromShoppingCartQuery request, CancellationToken cancellationToken)
        {
            var products = await _shoppingCartService.GetAllProducts(request.userId);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }
    }

}
