namespace Billing.Domain.Entities;

public class CustomerEntity
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Address { get; private set; }

    public IReadOnlyCollection<BillingEntity> Billings => _billings.AsReadOnly();
    private readonly List<BillingEntity> _billings = new();

    public CustomerEntity(Guid id, string name, string email, string address)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id inválido.");
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name é obrigatório.");
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email é obrigatório.");
        if (string.IsNullOrWhiteSpace(address)) throw new ArgumentException("Address é obrigatório.");

        Id = id;
        Name = name;
        Email = email;
        Address = address;
    }

    public void AddBilling(BillingEntity billing)
    {
        if (billing == null) throw new ArgumentNullException(nameof(billing));
        _billings.Add(billing);
    }
}
