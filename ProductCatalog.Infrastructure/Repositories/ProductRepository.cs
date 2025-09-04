using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Domain.IRepository;
using ProductCatalog.Infrastructure.Data;

namespace ProductCatalog.Infrastructure.Repositories
{
    public class ProductRepository(ApplicationDbContext db) : IProductRepository
    {
        public async Task<(IReadOnlyList<Product> items, int total)> GetPagedAsync(int pageNumber, int pageSize, CancellationToken ct)
        {
            var query = db.Products
                          .AsNoTracking()
                          .Where(p => !p.IsDeleted); 

            var total = await query.CountAsync(ct); 

            var items = await query
                .OrderBy(p => p.CreatedAt) 
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);

            return (items, total);
        }



        public Task<Product?> GetByIdAsync(Guid id, CancellationToken ct) =>
            db.Products
              .AsNoTracking()
              .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted, ct);


        public async Task<Product> AddAsync(Product product, CancellationToken ct)
        {
            db.Products.Add(product);
            await db.SaveChangesAsync(ct);
            return product;
        }

        public async Task UpdateAsync(Product product, CancellationToken ct)
        {
            db.Products.Update(product);
            await db.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(Product product, CancellationToken ct)
        {
            db.Products.Remove(product);
            await db.SaveChangesAsync(ct);
        }
    }
}
