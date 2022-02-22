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
    public class ChangeProductQuantityInShoppingCartCommand : IRequest<Unit>
    {
        public int userId;
        public int productId;
        public bool increasing;
        public ChangeProductQuantityInShoppingCartCommand(int userId, int productId, bool increasing)
        {
            this.userId = userId;
            this.productId = productId;
            this.increasing = increasing;
        }
    }
    public class ChangeProductQuantityShoppingCartCommandHandler : IRequestHandler<ChangeProductQuantityInShoppingCartCommand>
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ChangeProductQuantityShoppingCartCommandHandler(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        public async Task<Unit> Handle(ChangeProductQuantityInShoppingCartCommand request, CancellationToken cancellationToken)
        {
            await _shoppingCartService.ChangeQuantity(request.userId, request.productId, request.increasing);
            return Unit.Value;
        }
    }
}
