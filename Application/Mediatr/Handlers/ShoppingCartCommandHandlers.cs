using Application.Mediatr.Command;
using Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediatr.Handlers
{
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
