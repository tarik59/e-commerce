using EC_Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IShoppingCartService
    {
        public Task<IEnumerable<Product>> GetAllProducts(int userId);
        public Task AddProduct(int userId, int productId);
        public Task DeleteProduct(int userId, int productId);
        public Task IncreaseQuantity(int userId, int productId);

    }
}
