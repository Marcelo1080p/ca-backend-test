using Billing.Domain.Entities;
using Billing.Domain.Repositories;
using Billing.Infrastructure.contexts;
using Microsoft.EntityFrameworkCore;

namespace Billing.Infrastructure.Repositories;

public class BillingLineRepository : IBillingLineRepository
{
    private readonly ApplicationDbContext _context;

    public BillingLineRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<BillingLineEntity?> GetByIdAsync(Guid id)
    {
        return await _context.BillingLines.FindAsync(id);
    }

    public async Task<IEnumerable<BillingLineEntity>> GetAllAsync()
    {
        return await _context.BillingLines.ToListAsync();
    }

    public async Task AddAsync(BillingLineEntity billingLine)
    {
        await _context.BillingLines.AddAsync(billingLine);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(BillingLineEntity billingLine)
    {
        _context.BillingLines.Update(billingLine);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(BillingLineEntity billingLine)
    {
        _context.BillingLines.Remove(billingLine);
        await _context.SaveChangesAsync();
    }
}
