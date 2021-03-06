using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductAsync();
        Task<Product> GetByIdAsync(int id);
        // Task<IEnumerable<Product>> GetByCategoryAsync(int id);
        Task<Product> Create(Product category);
        Task<Product> Update(Product category);
        Task<Product> Delete(Product category);
    }
}