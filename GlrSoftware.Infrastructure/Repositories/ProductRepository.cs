using GlrSoftware.Application.Interfaces;
using GlrSoftware.Domain.Entities;
using GlrSoftware.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GlrSoftware.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync() =>
        await _context.products.ToListAsync();

    public async Task<Product?> GetByIdAsync(int id) =>
        await _context.products.FindAsync(id);

    public async Task AddAsync(Product product)
    {
        await _context.products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _context.products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _context.products.FindAsync(id);
        if (product is not null)
        {
            _context.products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
