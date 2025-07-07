using Billing.Application.DTOs.Customer;

namespace Billing.Application.Interfaces;

public interface ICustomerAppService
{
    Task<CustomerResponse?> GetByIdAsync(Guid id);
    Task<bool> ExistsAsync(Guid customerId);
    Task<IEnumerable<CustomerResponse>> GetAllAsync();
    Task AddAsync(CustomerRequest request);
    Task UpdateAsync(CustomerUpdateRequest request);
    Task DeleteAsync(Guid id);
}
