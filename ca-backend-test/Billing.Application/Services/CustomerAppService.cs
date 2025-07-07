using Billing.Application.DTOs.Customer;
using Billing.Application.Interfaces;
using Billing.Domain.Entities;
using Billing.Domain.Repositories;

namespace Billing.Application.Services;

public class CustomerAppService : ICustomerAppService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerAppService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<CustomerResponse?> GetByIdAsync(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id inválido.");

        var customer = await _customerRepository.GetByIdAsync(id);
        if (customer == null) return null;

        return new CustomerResponse
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email,
            Address = customer.Address
        };
    }

    public async Task<bool> ExistsAsync(Guid customerId)
    {
        if (customerId == Guid.Empty) throw new ArgumentException("Id inválido.");
        var customer = await _customerRepository.GetByIdAsync(customerId);
        return customer != null;
    }

    public async Task<IEnumerable<CustomerResponse>> GetAllAsync()
    {
        var customers = await _customerRepository.GetAllAsync();

        return customers.Select(c => new CustomerResponse
        {
            Id = c.Id,
            Name = c.Name,
            Email = c.Email,
            Address = c.Address
        });
    }

    public async Task AddAsync(CustomerRequest request)
    {
        ValidateRequest(request);

        var customer = new CustomerEntity(Guid.NewGuid(), request.Name, request.Email, request.Address);
        await _customerRepository.AddAsync(customer);
    }

    public async Task UpdateAsync(CustomerUpdateRequest request)
    {
        if (request.Id == Guid.Empty) throw new ArgumentException("Id inválido.");
        ValidateRequest(request);

        var customer = new CustomerEntity(request.Id, request.Name, request.Email, request.Address);
        await _customerRepository.UpdateAsync(customer);
    }

    public async Task DeleteAsync(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id inválido.");

        var customer = await _customerRepository.GetByIdAsync(id);
        if (customer == null) throw new InvalidOperationException("Cliente não encontrado.");

        await _customerRepository.DeleteAsync(customer);
    }

    private void ValidateRequest(CustomerRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name)) throw new ArgumentException("Nome é obrigatório.");
        if (string.IsNullOrWhiteSpace(request.Email)) throw new ArgumentException("Email é obrigatório.");
        if (string.IsNullOrWhiteSpace(request.Address)) throw new ArgumentException("Endereço é obrigatório.");
    }
}
