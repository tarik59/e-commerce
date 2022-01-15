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
        public OrderService(IRepository<Order> repository)
        {
            _ordersRepository = repository;
        }
        public async Task AddOrderAsync(Order order)
        {
            await _ordersRepository.Insert(order);
        }

        public async Task DeleteOrderAsync(Order order)
        {
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
        public async Task CreateOrder(string userId)
        {
            new NotImplementedException();
        }
    }
}
