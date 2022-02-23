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

namespace Application.Mediatr.Query.ShoppingCart
{
    public class GetAllProductsFromShoppingCartQuery : IRequest<UserShoppingCartDto>
    {
        public int userId;
        public GetAllProductsFromShoppingCartQuery(int userId)
        {
            this.userId = userId;
        }
    }
    public class GetAllProductsFromShoppingCartQueryHandler : IRequestHandler<GetAllProductsFromShoppingCartQuery, UserShoppingCartDto>
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IMapper _mapper;

        public GetAllProductsFromShoppingCartQueryHandler(IShoppingCartService shoppingCartService, IMapper mapper)
        {
            _shoppingCartService = shoppingCartService;
            _mapper = mapper;
        }

        public async Task<UserShoppingCartDto> Handle(GetAllProductsFromShoppingCartQuery request, CancellationToken cancellationToken)
        {
            var products = await _shoppingCartService.GetShoppingCartForUser(request.userId);
            return products;
        }
    }

}
