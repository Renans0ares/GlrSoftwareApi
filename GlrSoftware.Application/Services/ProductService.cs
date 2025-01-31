using GlrSoftware.Application.Interfaces;
using GlrSoftware.Domain.Entities;

namespace GlrSoftware.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> GetAllAsync() =>
            await _repository.GetAllAsync();

        public async Task<Product?> GetByIdAsync(int id) =>
            await _repository.GetByIdAsync(id);

        public async Task AddAsync(Product product) =>
            await _repository.AddAsync(product);

        public async Task UpdateAsync(Product product) =>
            await _repository.UpdateAsync(product);

        public async Task DeleteAsync(int id) =>
            await _repository.DeleteAsync(id);
    }
}
