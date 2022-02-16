using Application.Contracts;
using Application.Repositories;
using Application.Services;
using EC_Domain.Entity;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EC_Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> _shoppingCartRepo;
        private readonly IRepository<ProductInShoppingCart> _productInShoppingCartRepo;
        private readonly IRepository<Product> _productRepo;
        public ShoppingCartService(IRepository<ShoppingCart> repository, IRepository<ProductInShoppingCart> productInShoppingCartRepo, IRepository<Product> productRepo)
        {
            _shoppingCartRepo = repository;
            _productInShoppingCartRepo = productInShoppingCartRepo;
            _productRepo = productRepo;
        }

        public async Task AddProduct(int userId, int productId)
        {
            ShoppingCart shoppingCart = await GetShoppingCart(userId);

            if (shoppingCart.products.SingleOrDefault(p => p.Id == productId) != null)
            {
                throw new Exception("Product already in cart");
            }
            var product = await _productRepo.Find(productId);
            shoppingCart.products.Add(product);

            await _shoppingCartRepo.SaveChanges();
        }

        public async Task ChangeQuantity(int userId, int productId, bool increasing)
        {
            ShoppingCart shoppingCart = await GetShoppingCart(userId);

            if (shoppingCart.products.SingleOrDefault(p => p.Id == productId) == null)
            {
                throw new Exception("Error - product does not exists in cart");
            }
            var productInCart = await _productInShoppingCartRepo.Find(shoppingCart.Id, productId);

            IncreaseOrDecrease(productInCart, increasing);
            
            await _shoppingCartRepo.SaveChanges();
        }

        public async Task DeleteProduct(int userId, int productId)
        {
            ShoppingCart shoppingCart = await GetShoppingCart(userId);

            if (shoppingCart.products.SingleOrDefault(p => p.Id == productId) == null)
            {
                throw new Exception("Error - product does not exists in cart");
            }
            var product = await _productRepo.Find(productId);
            shoppingCart.products.Remove(product);

            await _shoppingCartRepo.SaveChanges();
        }
        public async Task<IEnumerable<Product>> GetAllProducts(int userId)
        {
            var shoppingCart = await GetShoppingCart(userId);
            return shoppingCart.products;
        }

        private async Task<ShoppingCart> GetShoppingCart(int userId)
        {
            var shoppingCart = await _shoppingCartRepo.Get(c => c.AppUserId == userId, "products");

            if (shoppingCart == null)
            {
                throw new Exception("Shopping cart with that id does not exist");
            }
            return shoppingCart;
        }

        private void IncreaseOrDecrease(ProductInShoppingCart productInCart, bool increasing)
        {
            if (increasing)
            {
                productInCart.Quantity++;
                return;
            }
            productInCart.Quantity--;
            if (productInCart.Quantity <= 0)
            {
                _productInShoppingCartRepo.Remove(productInCart);
            }
        }
    }
}
