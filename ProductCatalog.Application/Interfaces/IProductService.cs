using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Application.Interfaces
{
    public interface IProductService
    {
        Task<PagedResponse<ProductDto>> GetAsync(PagedRequest request, CancellationToken ct);
        Task<ProductDto?> GetByIdAsync(Guid id, CancellationToken ct);  
        Task<ProductDto> CreateAsync(CreateProductRequest request, CancellationToken ct);
        Task<bool> UpdateAsync(Guid id, UpdateProductRequest request, CancellationToken ct); 
        Task<bool> DeleteAsync(Guid id, CancellationToken ct); 
    }
}
