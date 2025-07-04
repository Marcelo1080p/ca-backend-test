using Billing.Domain.Entities;
using FluentAssertions;

namespace Tests.Domain.Tests
{
    public class BillingLineTests
    {
        private ProductEntity CreateValidProduct(string name = "Produto Teste") =>
            new ProductEntity(Guid.NewGuid(), name);

        [Fact]
        public void Constructor_WithValidParameters_ShouldCreateBillingLine()
        {
            var id = Guid.NewGuid();
            var product = CreateValidProduct();
            var description = "Descrição do produto";
            var quantity = 3;
            var unitPrice = 15.5m;

            var billingLine = new BillingLineEntity(id, product, description, quantity, unitPrice);

            billingLine.Id.Should().Be(id);
            billingLine.Product.Should().Be(product);
            billingLine.Description.Should().Be(description);
            billingLine.Quantity.Should().Be(quantity);
            billingLine.UnitPrice.Should().Be(unitPrice);
            billingLine.Subtotal.Should().Be(quantity * unitPrice);
        }

        [Fact]
        public void Constructor_WithZeroQuantity_ShouldHaveZeroSubtotal()
        {
            var billingLine = new BillingLineEntity(
                Guid.NewGuid(),
                CreateValidProduct(),
                "Desc",
                0,
                10m);

            billingLine.Subtotal.Should().Be(0m);
        }

        [Fact]
        public void Constructor_WithNegativeQuantity_ShouldThrowArgumentException()
        {
            Action act = () => new BillingLineEntity(
                Guid.NewGuid(),
                CreateValidProduct(),
                "Desc",
                -1,
                10m);

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Constructor_WithNegativeUnitPrice_ShouldThrowArgumentException()
        {
            Action act = () => new BillingLineEntity(
                Guid.NewGuid(),
                CreateValidProduct(),
                "Desc",
                1,
                -5m);

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Constructor_WithNullProduct_ShouldThrowArgumentNullException()
        {
            Action act = () => new BillingLineEntity(
                Guid.NewGuid(),
                null,
                "Desc",
                1,
                10m);

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
