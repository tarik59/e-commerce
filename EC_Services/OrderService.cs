using Application.Repositories;
using Application.Services;
using EC_Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EC_Services.Implementations
{
    public class OrderService : IOrderService
    {
        public IRepository<Order> _ordersRepository { get; set; }
        public IRepository<ShoppingCart> _shoppingCartRepo { get; set; }
        public OrderService(IRepository<Order> repository, IRepository<ShoppingCart> shoppingCartRepo)
        {
            _ordersRepository = repository;
            _shoppingCartRepo = shoppingCartRepo;
        }
        public async Task AddOrderAsync(Order order)
        {
            await _ordersRepository.Insert(order);
        }

        public async Task DeleteOrderAsync(int id)
        {
            Order order=await _ordersRepository.Get(id);
            await _ordersRepository.Delete(order);
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _ordersRepository.Get(id);
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _ordersRepository.GetAll();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            await _ordersRepository.Update(order);
        }
        public async Task CreateOrder(int userId)
        {
           var shoppingcart=await _shoppingCartRepo.Get(x=>x.AppUserId == userId,"products");
            var order = new Order()
            {
                products = shoppingcart.products,
                userId = userId
            };
           await _ordersRepository.Insert(order);
           foreach(var product in shoppingcart.products)
            {
                product.Quantity--;
            }
           shoppingcart.products.Clear();
            await _ordersRepository.SaveChanges();
        }
    }
}
