using Billing.Domain.Entities;

namespace Billing.Domain.Repositories;

public interface IBillingLineRepository
{
    Task<BillingLineEntity?> GetByIdAsync(Guid id);
    Task<IEnumerable<BillingLineEntity>> GetAllAsync();
    Task AddAsync(BillingLineEntity billingLine);
    Task UpdateAsync(BillingLineEntity billingLine);
    Task DeleteAsync(BillingLineEntity billingLine);
}

