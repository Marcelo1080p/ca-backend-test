using Billing.Domain.Entities;
using Billing.Domain.Repositories;
using Billing.Infrastructure.contexts;
using Microsoft.EntityFrameworkCore;

namespace Billing.Infrastructure.Repositories;

public class BillingRepository : IBillingRepository
{
    private readonly ApplicationDbContext _context;

    public BillingRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<BillingEntity?> GetByIdAsync(Guid id)
    {
        return await _context.Billings.FindAsync(id);
    }

    public async Task<IEnumerable<BillingEntity>> GetAllAsync()
    {
        return await _context.Billings.ToListAsync();
    }

    public async Task AddAsync(BillingEntity billing)
    {
        await _context.Billings.AddAsync(billing);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(BillingEntity billing)
    {
        _context.Billings.Update(billing);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(BillingEntity billing)
    {
        _context.Billings.Remove(billing);
        await _context.SaveChangesAsync();
    }
}
