using Billing.Application.DTOs.Product;
using Billing.Application.Interfaces;
using Billing.Domain.Entities;
using Billing.Domain.Repositories;

namespace Billing.Application.Services;

public class ProductAppService : IProductAppService
{
    private readonly IProductRepository _productRepository;

    public ProductAppService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductResponse?> GetByIdAsync(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id inválido.");

        var product = await _productRepository.GetByIdAsync(id);
        if (product == null) return null;

        return new ProductResponse
        {
            Id = product.Id,
            Name = product.Name
        };
    }

    public async Task<bool> ExistsAsync(Guid productId)
    {
        if (productId == Guid.Empty) throw new ArgumentException("Id inválido.");
        var product = await _productRepository.GetByIdAsync(productId);
        return product != null;
    }

    public async Task<IEnumerable<ProductResponse>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();

        return products.Select(p => new ProductResponse
        {
            Id = p.Id,
            Name = p.Name
        });
    }

    public async Task AddAsync(ProductRequest request)
    {
        ValidateRequest(request);

        var product = new ProductEntity(Guid.NewGuid(), request.Name);
        await _productRepository.AddAsync(product);
    }

    public async Task UpdateAsync(ProductUpdateRequest request)
    {
        if (request.Id == Guid.Empty) throw new ArgumentException("Id inválido.");
        ValidateRequest(request);

        var product = new ProductEntity(request.Id, request.Name);
        await _productRepository.UpdateAsync(product);
    }

    public async Task DeleteAsync(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id inválido.");

        var product = await _productRepository.GetByIdAsync(id);
        if (product == null) throw new InvalidOperationException("Produto não encontrado.");

        await _productRepository.DeleteAsync(product);
    }

    private void ValidateRequest(ProductRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name)) throw new ArgumentException("Nome é obrigatório.");
    }
}
