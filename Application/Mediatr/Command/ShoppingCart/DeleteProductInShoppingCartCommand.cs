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
    public class DeleteProductInShoppingCartCommand : IRequest<Unit>
    {
        public int userId;
        public int productId;

        public DeleteProductInShoppingCartCommand(int userId, int productId)
        {
            this.userId = userId;
            this.productId = productId;
        }
    }
    public class DeleteProductInShoppingCartCommandHandler : IRequestHandler<DeleteProductInShoppingCartCommand>
    {
        private readonly IShoppingCartService _shoppingCartService;

        public DeleteProductInShoppingCartCommandHandler(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        public async Task<Unit> Handle(DeleteProductInShoppingCartCommand request, CancellationToken cancellationToken)
        {
            await _shoppingCartService.DeleteProduct(request.userId, request.productId);
            return Unit.Value;
        }
    }
}
