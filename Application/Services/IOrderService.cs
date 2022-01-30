using EC_Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IOrderService
    {
        public Task<IEnumerable<Order>> GetOrdersAsync();
        public Task<Order> GetOrderByIdAsync(int id);
        public Task AddOrderAsync(Order order);
        public Task UpdateOrderAsync(Order order);
        public Task DeleteOrderAsync(int id);
        public Task CreateOrder(int userId);
        //Task<bool> SaveAllAsync();

    }
}
