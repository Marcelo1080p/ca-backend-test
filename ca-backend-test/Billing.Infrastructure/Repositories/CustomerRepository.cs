
using Billing.Domain.Entities;
using Billing.Domain.Repositories;
using Billing.Infrastructure.contexts;
using Microsoft.EntityFrameworkCore;
namespace Billing.Infrastructure.Repositories;


public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(CustomerEntity customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(CustomerEntity customer)
    {
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<CustomerEntity?> GetByIdAsync(Guid id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public async Task UpdateAsync(CustomerEntity customer)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
    }
}

