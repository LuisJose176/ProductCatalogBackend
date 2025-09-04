using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Domain.IRepository
{
    public interface IProductRepository
    {
        Task<(IReadOnlyList<Product> items, int total)> GetPagedAsync(int pageNumber, int pageSize, CancellationToken ct);
        Task<Product?> GetByIdAsync(Guid id, CancellationToken ct); 
        Task<Product> AddAsync(Product product, CancellationToken ct);
        Task UpdateAsync(Product product, CancellationToken ct);
        Task DeleteAsync(Product product, CancellationToken ct);    
    }
}
