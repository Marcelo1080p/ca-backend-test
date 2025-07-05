using Billing.Domain.Entities;

namespace Billing.Domain.Repositories;

public interface IBillingRepository
{
    Task<BillingEntity?> GetByIdAsync(Guid id);
    Task<IEnumerable<BillingEntity>> GetAllAsync();
    Task AddAsync(BillingEntity billing);
    Task UpdateAsync(BillingEntity billing);
    Task DeleteAsync(BillingEntity billing);
}

