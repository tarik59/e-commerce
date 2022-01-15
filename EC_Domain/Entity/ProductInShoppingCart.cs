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
