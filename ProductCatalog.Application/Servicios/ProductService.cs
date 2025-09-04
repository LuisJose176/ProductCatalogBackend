using ProductCatalog.Application.DTOs;
using ProductCatalog.Application.Interfaces;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Domain.IRepository;

namespace ProductCatalog.Application.Servicios
{
    public class ProductService(IProductRepository repo) : IProductService
    {
        public async Task<PagedResponse<ProductDto>> GetAsync(PagedRequest request, CancellationToken ct)
        {
            var (items, total) = await repo.GetPagedAsync(request.PageNumber, request.PageSize, ct);
            var mapped = items.Select(ToDto).ToList();
            return new PagedResponse<ProductDto>(mapped, total, request.PageNumber, request.PageSize);
        }

        public async Task<ProductDto?> GetByIdAsync(Guid id, CancellationToken ct) 
        {
            var entity = await repo.GetByIdAsync(id, ct);
            return entity is null ? null : ToDto(entity);
        }

        public async Task<ProductDto> CreateAsync(CreateProductRequest request, CancellationToken ct)
        {
            var entity = new Product
            {
                Id = Guid.NewGuid(), 
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };

            var created = await repo.AddAsync(entity, ct);
            return ToDto(created);
        }

        public async Task<bool> UpdateAsync(Guid id, UpdateProductRequest request, CancellationToken ct) 
        {
            var current = await repo.GetByIdAsync(id, ct);
            if (current is null) return false;

            current.Name = request.Name;
            current.Description = request.Description;
            current.Price = request.Price;

            await repo.UpdateAsync(current, ct);
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken ct)
        {
            var current = await repo.GetByIdAsync(id, ct);
            if (current is null) return false;

            await repo.DeleteAsync(current, ct);
            return true;
        }

        private static ProductDto ToDto(Product p) =>
            new(p.Id, p.Name, p.Description, p.Price, p.CreatedAt);
    }
}
