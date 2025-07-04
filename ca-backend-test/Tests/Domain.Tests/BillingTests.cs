using Billing.Domain.Entities;
using FluentAssertions;

namespace Tests.Domain.Tests
{
    public class BillingTests
    {
        private CustomerEntity CreateValidCustomer() =>
            new CustomerEntity(
                Guid.NewGuid(),
                "Cliente Teste",
                "teste@teste.com",
                "OutroValor");

        private ProductEntity CreateValidProduct(string name) =>
            new ProductEntity(
                Guid.NewGuid(),
                name);

        private List<BillingLineEntity> CreateValidLines()
        {
            return new List<BillingLineEntity>
            {
                new BillingLineEntity(
                    Guid.NewGuid(),
                    CreateValidProduct("Produto A"),
                    "Descrição Produto A",
                    2,
                    10.0m),

                new BillingLineEntity(
                    Guid.NewGuid(),
                    CreateValidProduct("Produto B"),
                    "Descrição Produto B",
                    1,
                    20.0m),
            };
        }

        [Fact]
        public void Constructor_WithValidParameters_ShouldCreateBilling()
        {
            var id = Guid.NewGuid();
            var invoiceNumber = "INV-123";
            var customer = CreateValidCustomer();
            var date = DateTime.Now;
            var dueDate = date.AddDays(30);
            var currency = "BRL";
            var lines = CreateValidLines();

            var billing = new BillingEntity(id, invoiceNumber, customer, date, dueDate, currency, lines);

            billing.Id.Should().Be(id);
            billing.InvoiceNumber.Should().Be(invoiceNumber);
            billing.Customer.Should().Be(customer);
            billing.Date.Should().Be(date);
            billing.DueDate.Should().Be(dueDate);
            billing.Currency.Should().Be(currency);
            billing.Lines.Should().BeEquivalentTo(lines);
            billing.TotalAmount.Should().Be(40.0m);
        }

        [Fact]
        public void Constructor_WithEmptyLines_ShouldSetTotalAmountToZero()
        {
            var id = Guid.NewGuid();
            var invoiceNumber = "INV-456";
            var customer = CreateValidCustomer();
            var date = DateTime.Now;
            var dueDate = date.AddDays(15);
            var currency = "USD";
            var lines = new List<BillingLineEntity>();

            var billing = new BillingEntity(id, invoiceNumber, customer, date, dueDate, currency, lines);

            billing.Lines.Should().BeEmpty();
            billing.TotalAmount.Should().Be(0.0m);
        }

        [Fact]
        public void Constructor_WithNullLines_ShouldThrowArgumentNullException()
        {
            var id = Guid.NewGuid();
            var invoiceNumber = "INV-789";
            var customer = CreateValidCustomer();
            var date = DateTime.Now;
            var dueDate = date.AddDays(10);
            var currency = "EUR";

            Action act = () => new BillingEntity(id, invoiceNumber, customer, date, dueDate, currency, null);

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_WithNullCustomer_ShouldThrowArgumentNullException()
        {
            var id = Guid.NewGuid();
            var invoiceNumber = "INV-999";
            var date = DateTime.Now;
            var dueDate = date.AddDays(5);
            var currency = "BRL";
            var lines = CreateValidLines();

            Action act = () => new BillingEntity(id, invoiceNumber, null, date, dueDate, currency, lines);

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
