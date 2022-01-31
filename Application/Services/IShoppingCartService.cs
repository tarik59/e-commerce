using Application.Contracts;
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
        public Task<IEnumerable<ProductDto>> GetAllProducts(int userId);
        public Task AddProduct(int userId, int productId);
        public Task DeleteProduct(int userId, int productId);
        public Task ChangeQuantity(int userId, int productId, bool increasing);

    }
}
