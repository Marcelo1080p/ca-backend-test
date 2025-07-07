using Billing.Domain.Entities;

public interface IProductService
{
    Task<ProductEntity?> GetByIdAsync(Guid id);
    Task<IEnumerable<ProductEntity>> GetAllAsync();
    Task AddAsync(ProductEntity product);
    Task UpdateAsync(ProductEntity product);
    Task DeleteAsync(ProductEntity product);

    Task<bool> ExistsAsync(Guid id);
}
