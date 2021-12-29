using EC_Domain.Entity;
using EC_Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC_Repository
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Gender> Genders { get; set;}
        public DbSet<Product> Products { get; set;}
        public DbSet<ShoppingCart> shoppingCarts { get; set;}
        public DbSet<TypeOfProduct> typeOfProducts { get; set;}
        public DbSet<Brand> brands { get; set;}
        public DbSet<ProductInShoppingCart> productInShoppingCarts { get; set;}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ProductInShoppingCart>()
                .HasKey(k => new { k.shoppingCartId,k.productId});
        }
    }
}
