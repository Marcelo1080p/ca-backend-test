using Billing.Domain.Entities;

public interface IBillingService
{
    Task<BillingEntity?> GetByIdAsync(Guid id);
    Task<IEnumerable<BillingEntity>> GetAllAsync();
    Task AddAsync(BillingEntity billing);
    Task UpdateAsync(BillingEntity billing);
    Task DeleteAsync(BillingEntity billing);
}
