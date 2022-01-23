using EC_Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EC_Domain.Mappings
{
    public class ProductInOrderMap
    {
        public ProductInOrderMap(EntityTypeBuilder<ProductInOrder> entityTypeBuilder)
        {
            entityTypeBuilder
                .HasKey(k => new { k.orderId, k.productId });
        }
    }

    public class ProductInShoppingCartMap
    {
        public ProductInShoppingCartMap(EntityTypeBuilder<ProductInShoppingCart> entityTypeBuilder)
        {
            entityTypeBuilder
                .HasKey(k => new { k.shoppingCartId, k.productId });
        }
    }
    public class AppUserRolesMap
    {
        public AppUserRolesMap(EntityTypeBuilder<AppUserRole> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(k => new { k.UserId, k.RoleId });
        }
    }
}
