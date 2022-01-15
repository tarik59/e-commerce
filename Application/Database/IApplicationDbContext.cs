using EC_Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Application.Database
{
    public interface IApplicationDbContext
    {
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> shoppingCarts { get; set; }
        public DbSet<TypeOfProduct> typeOfProducts { get; set; }
        public DbSet<Brand> brands { get; set; }
        public DbSet<ProductInShoppingCart> productInShoppingCarts { get; set; }
    }
}
