namespace Billing.Domain.Entities;

public class BillingEntity
{
    public Guid Id { get; private set; }
    public string InvoiceNumber { get; private set; }
    public CustomerEntity Customer { get; private set; }
    public DateTime Date { get; private set; }
    public DateTime DueDate { get; private set; }
    public decimal TotalAmount { get; private set; }
    public string Currency { get; private set; }
    public List<BillingLineEntity> Lines { get; private set; }

    public BillingEntity(Guid id, string invoiceNumber, CustomerEntity customer, DateTime date, DateTime dueDate, string currency, List<BillingLineEntity> lines)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id inválido.");
        if (string.IsNullOrWhiteSpace(invoiceNumber)) throw new ArgumentException("InvoiceNumber é obrigatório.");
        if (customer == null) throw new ArgumentNullException(nameof(customer));
        if (date == default) throw new ArgumentException("Date inválida.");
        if (dueDate == default) throw new ArgumentException("DueDate inválida.");
        if (string.IsNullOrWhiteSpace(currency)) throw new ArgumentException("Currency é obrigatório.");
        if (lines == null || lines.Count == 0) throw new ArgumentException("Deve ter ao menos uma linha de faturamento.");

        Id = id;
        InvoiceNumber = invoiceNumber;
        Customer = customer;
        Date = date;
        DueDate = dueDate;
        Currency = currency;
        Lines = lines;

        
        TotalAmount = 0;
        foreach (var line in Lines)
        {
            TotalAmount += line.Subtotal;
        }
    }
}