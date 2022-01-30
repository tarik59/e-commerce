using EC_Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetProductsAsync();
        public Task<Product> GetProductByIdAsync(int id);
        public Task AddProductAsync(Product Product);
        public Task UpdateProductAsync(Product Product);
        public Task DeleteProductAsync(int id);
    }
}
