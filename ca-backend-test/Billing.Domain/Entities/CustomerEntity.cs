namespace Billing.Domain.Entities
{
    public class CustomerEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }

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
    }

}
