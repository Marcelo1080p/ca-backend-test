using Billing.Domain.Entities;

public interface ICustomerService
{
    Task<CustomerEntity?> GetByIdAsync(Guid id);
    Task<IEnumerable<CustomerEntity>> GetAllAsync();
    Task AddAsync(CustomerEntity customer);
    Task UpdateAsync(CustomerEntity customer);
    Task DeleteAsync(CustomerEntity customer);

    Task<bool> ExistsAsync(Guid id);
}
