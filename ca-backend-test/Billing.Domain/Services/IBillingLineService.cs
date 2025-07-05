using Billing.Domain.Entities;

public interface IBillingLineService
{
    Task<BillingLineEntity?> GetByIdAsync(Guid id);
    Task<IEnumerable<BillingLineEntity>> GetAllAsync();
    Task AddAsync(BillingLineEntity billingLine);
    Task UpdateAsync(BillingLineEntity billingLine);
    Task DeleteAsync(BillingLineEntity billingLine);
}
