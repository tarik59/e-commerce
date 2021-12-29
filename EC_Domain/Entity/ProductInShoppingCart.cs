using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC_Domain.Entity
{
    public class ProductInShoppingCart
    {
        public int productId { get; set; }
        public Product Product { get; set; }
        public int shoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
