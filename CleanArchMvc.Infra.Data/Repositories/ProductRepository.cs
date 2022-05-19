using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetProductAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product> GetByIdAsync(int id)
        {
            // eager loading
            return await _context.Products.Include(p => p.Category)
                .SingleOrDefaultAsync(p => p.Id == id);
        }
        // public async Task<IEnumerable<Product>> GetByCategoryAsync(int id)
        // {
        //     return await _context.Products.Include(p => p.Category)
        //         .Where(p => p.CategoryId == id).ToListAsync();
        // }
        public async Task<Product> Create(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<Product> Update(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<Product> Delete(Product product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

    }
}