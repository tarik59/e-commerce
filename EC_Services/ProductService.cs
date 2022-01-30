using Application.Repositories;
using Application.Services;
using EC_Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC_Services
{
    public class ProductService : IProductService
    {
        public IRepository<Product> _productsRepository { get; set; }
        public ProductService(IRepository<Product> productsRepository)
        {
            _productsRepository = productsRepository;
        }

     
        public async Task AddProductAsync(Product product)
        {
            await _productsRepository.Insert(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productsRepository.Delete(await _productsRepository.Get(id));
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
           return await _productsRepository.Get(id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productsRepository.GetAll();
        }

        public async Task UpdateProductAsync(Product product)
        {
           await _productsRepository.Update(product);
        }
    }
}
