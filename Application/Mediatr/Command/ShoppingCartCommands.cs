using EC_Domain.Entity;
using MediatR;

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
}
