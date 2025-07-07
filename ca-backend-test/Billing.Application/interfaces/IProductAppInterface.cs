using Billing.Application.DTOs.Product;

namespace Billing.Application.Interfaces;

public interface IProductAppService
{
    Task<ProductResponse?> GetByIdAsync(Guid id);
    Task<bool> ExistsAsync(Guid productId);
    Task<IEnumerable<ProductResponse>> GetAllAsync();
    Task AddAsync(ProductRequest request);
    Task UpdateAsync(ProductUpdateRequest request);
    Task DeleteAsync(Guid id);
}
