using Billing.Domain.Entities;
using Billing.Domain.Repositories;

public class BillingAppService : IBillingAppService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IProductRepository _productRepository;
    private readonly IBillingRepository _billingRepository;
    private readonly IExternalBillingApiService _externalApi;

    public BillingAppService(
        ICustomerRepository customerRepository,
        IProductRepository productRepository,
        IBillingRepository billingRepository,
        IExternalBillingApiService externalApi)
    {
        _customerRepository = customerRepository;
        _productRepository = productRepository;
        _billingRepository = billingRepository;
        _externalApi = externalApi;
    }

    public async Task ImportBillingFromExternalApiAsync()
    {
        var billings = await _externalApi.GetBillingsAsync();

        if (billings == null || !billings.Any())
            throw new Exception("Nenhum billing retornado da API externa.");

        var billingRequest = billings.First();

        var customer = await _customerRepository.GetByIdAsync(billingRequest.CustomerId);
        if (customer == null)
            throw new InvalidOperationException("Cliente não encontrado.");

        var missingProducts = new List<Guid>();

        foreach (var line in billingRequest.Lines)
        {
            var product = await _productRepository.GetByIdAsync(line.ProductId);
            if (product == null)
                missingProducts.Add(line.ProductId);
        }

        if (missingProducts.Any())
            throw new InvalidOperationException("Produtos ausentes: " + string.Join(", ", missingProducts));

        var billingLines = billingRequest.Lines
            .Select(line => new BillingLineEntity(
                line.ProductId,
                line.Description,
                line.Quantity,
                line.UnitPrice))
            .ToList();

        var billingEntity = new BillingEntity(
            Guid.NewGuid(),
            billingRequest.InvoiceNumber,
            customer,
            billingRequest.Date,
            billingRequest.DueDate,
            billingRequest.Currency,
            billingLines);

        await _billingRepository.AddAsync(billingEntity);
    }
}
