using EC_Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
