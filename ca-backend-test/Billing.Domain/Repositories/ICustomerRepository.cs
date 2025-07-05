using Billing.Domain.Entities;

namespace Billing.Domain.Repositories;

public interface ICustomerRepository
{
    Task<CustomerEntity?> GetByIdAsync(Guid id);
    Task<IEnumerable<CustomerEntity>> GetAllAsync();
    Task AddAsync(CustomerEntity customer);
    Task UpdateAsync(CustomerEntity customer);
    Task DeleteAsync(CustomerEntity customer);
}

