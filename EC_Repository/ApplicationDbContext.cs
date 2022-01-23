using Application.Database;
using EC_Domain.Entity;
using EC_Domain.Identity;
using EC_Domain.Mappings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace EC_Repository
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int,
        IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>,
        IdentityUserToken<int>>, IApplicationDbContext
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
            new AppUserRolesMap(builder.Entity<AppUserRole>());

            new ProductInOrderRelationalMap(builder.Entity<Order>());
            new ProductInShoppingCartRelationalMap(builder.Entity<Product>());
            new AppUserRoleRelationalMap(builder.Entity<AppUser>());
        }
    }
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlite(connectionString);

            return new ApplicationDbContext(builder.Options);
        }
    }
}
