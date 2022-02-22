using Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediatr.Command.ShoppingCart
{
    public class AddProductInShoppingCartCommand : IRequest<Unit>
    {
        public int userId;
        public int productId;

        public AddProductInShoppingCartCommand(int userId, int productId)
        {
            this.userId = userId;
            this.productId = productId;
        }
    }
    public class AddProductInShoppingCartCommandHandler : IRequestHandler<AddProductInShoppingCartCommand>
    {
        private readonly IShoppingCartService _shoppingCartService;

        public AddProductInShoppingCartCommandHandler(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        public async Task<Unit> Handle(AddProductInShoppingCartCommand request, CancellationToken cancellationToken)
        {
            await _shoppingCartService.AddProduct(request.userId, request.productId);
            return Unit.Value;
        }
    }
}
