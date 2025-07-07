using Billing.Domain.Entities;

namespace Billing.Domain.Repositories;

public interface IProductRepository
{
    Task<ProductEntity?> GetByIdAsync(Guid id);
    Task<IEnumerable<ProductEntity>> GetAllAsync();
    Task AddAsync(ProductEntity product);
    Task UpdateAsync(ProductEntity product);
    Task DeleteAsync(ProductEntity product);

    Task<bool> ExistsAsync(Guid id);
}
