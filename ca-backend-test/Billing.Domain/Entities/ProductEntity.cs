namespace Billing.Domain.Entities;

public class ProductEntity
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public ProductEntity(Guid id, string name)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id inválido.");
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Nome do produto é obrigatório.");

        Id = id;
        Name = name;
    }

    private ProductEntity() { }

    
    public void UpdateName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName)) throw new ArgumentException("Nome do produto é obrigatório.");
        Name = newName;
    }
}
