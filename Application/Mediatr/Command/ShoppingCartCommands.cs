using Application.Services;
using EC_Domain.Entity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediatr.Command
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
