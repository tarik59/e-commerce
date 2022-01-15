using Application.Database;
using EC_Domain.Entity;
using EC_Domain.Identity;
using EC_Domain.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EC_Repository
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> shoppingCarts { get; set; }
        public DbSet<TypeOfProduct> typeOfProducts { get; set; }
        public DbSet<Brand> brands { get; set; }
        public DbSet<ProductInShoppingCart> productInShoppingCarts { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new ProductInOrderMap(builder.Entity<ProductInOrder>());
            new ProductInShoppingCartMap(builder.Entity<ProductInShoppingCart>());
            new ProductInOrderRelationalMap(builder.Entity<Order>());
            new ProductInShoppingCartRelationalMap(builder.Entity<Product>());

        }
    }
}
