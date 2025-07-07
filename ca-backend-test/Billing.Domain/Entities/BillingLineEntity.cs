namespace Billing.Domain.Entities;

public class BillingLineEntity
{
    public Guid Id { get; private set; }

    public Guid ProductId { get; private set; }
    public ProductEntity? Product { get; private set; }

    public Guid BillingId { get; private set; }
    public BillingEntity? Billing { get; private set; }

    public string? Description { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal Subtotal { get; private set; }

    public BillingLineEntity(
        Guid id,
        ProductEntity product,
        string description,
        int quantity,
        decimal unitPrice)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id inválido.");
        if (product == null) throw new ArgumentNullException(nameof(product));
        if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Descrição é obrigatória.");
        if (quantity <= 0) throw new ArgumentException("Quantidade deve ser maior que zero.");
        if (unitPrice <= 0) throw new ArgumentException("Preço unitário deve ser maior que zero.");

        Id = id;
        Product = product;
        ProductId = product.Id;
        Description = description;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Subtotal = quantity * unitPrice;
    }

    private BillingLineEntity() { }

    public BillingLineEntity(Guid productId, string description, int quantity, decimal unitPrice)
    {
        ProductId = productId;
        Description = description;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}
