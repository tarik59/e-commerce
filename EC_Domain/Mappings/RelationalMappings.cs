using EC_Domain.Entity;
using EC_Domain.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EC_Domain.Mappings
{
    public class ProductInOrderRelationalMap
    {
        public ProductInOrderRelationalMap(EntityTypeBuilder<Order> entityTypeBuilder)
        {
            entityTypeBuilder.HasMany(x => x.products)
               .WithMany(x => x.orders)
               .UsingEntity<ProductInOrder>(
                   x => x.HasOne(x => x.Product)
                   .WithMany().HasForeignKey(x => x.productId),
                   x => x.HasOne(x => x.Order)
                  .WithMany().HasForeignKey(x => x.orderId));
        }
    }
    public class ProductInShoppingCartRelationalMap
    {
        public ProductInShoppingCartRelationalMap(EntityTypeBuilder<Product> entityTypeBuilder)
        {
            entityTypeBuilder.HasMany(x => x.shoppingCarts)
               .WithMany(x => x.products)
               .UsingEntity<ProductInShoppingCart>(
                   x => x.HasOne(x => x.ShoppingCart)
                   .WithMany().HasForeignKey(x => x.shoppingCartId),
                   x => x.HasOne(x => x.Product)
                  .WithMany().HasForeignKey(x => x.productId));
        }
    }
    public class AppUserRoleRelationalMap
    {
        public AppUserRoleRelationalMap(EntityTypeBuilder<AppUser> entityTypeBuilder)
        {
            entityTypeBuilder.HasMany(x => x.Roles)
               .WithMany(x => x.Users)
               .UsingEntity<AppUserRole>(
                   x => x.HasOne(x => x.Role)
                   .WithMany().HasForeignKey(x => x.RoleId),
                   x => x.HasOne(x => x.User)
                  .WithMany().HasForeignKey(x => x.UserId));
        }
    }
}
