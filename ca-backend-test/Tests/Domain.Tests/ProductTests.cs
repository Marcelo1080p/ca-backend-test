using Billing.Domain.Entities;
using FluentAssertions;

namespace Tests.Domain.Tests;

public class ProductTests
{
    [Fact]
    public void Constructor_WithValidParameters_ShouldCreateProduct()
    {
        var id = Guid.NewGuid();
        var name = "Produto Teste";

        var product = new ProductEntity(id, name);

        product.Id.Should().Be(id);
        product.Name.Should().Be(name);
    }

    [Fact]
    public void Constructor_WithEmptyId_ShouldThrowArgumentException()
    {
        Action act = () => new ProductEntity(Guid.Empty, "Produto Teste");

        act.Should().Throw<ArgumentException>()
           .WithMessage("Id inválido.");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Constructor_WithInvalidName_ShouldThrowArgumentException(string invalidName)
    {
        var id = Guid.NewGuid();
        Action act = () => new ProductEntity(id, invalidName);

        act.Should().Throw<ArgumentException>()
           .WithMessage("Nome é obrigatório.");
    }
}
