using Billing.Domain.Entities;
using Moq;

public class IProductServiceTests
{
    private readonly Mock<IProductService> _mockService;

    public IProductServiceTests()
    {
        _mockService = new Mock<IProductService>();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnProduct_WhenIdIsValid()
    {
        var id = Guid.NewGuid();
        var product = new ProductEntity(id, "Produto A");
        _mockService.Setup(s => s.GetByIdAsync(id)).ReturnsAsync(product);

        var result = await _mockService.Object.GetByIdAsync(id);

        Assert.NotNull(result);
        Assert.Equal("Produto A", result.Name);
        
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnProductList()
    {
        var products = new List<ProductEntity>
        {
            new ProductEntity(Guid.NewGuid(), "Produto A"),
            new ProductEntity(Guid.NewGuid(), "Produto B")
        };

        _mockService.Setup(s => s.GetAllAsync()).ReturnsAsync(products);

        var result = await _mockService.Object.GetAllAsync();

        Assert.NotNull(result);
        Assert.Collection(result,
            p => Assert.Equal("Produto A", p.Name),
            p => Assert.Equal("Produto B", p.Name));
    }

    [Fact]
    public async Task AddAsync_ShouldBeCalledOnce()
    {
        var product = new ProductEntity(Guid.NewGuid(), "Novo Produto");

        _mockService.Setup(s => s.AddAsync(product)).Returns(Task.CompletedTask);

        await _mockService.Object.AddAsync(product);

        _mockService.Verify(s => s.AddAsync(product), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ShouldBeCalledOnce()
    {
        var product = new ProductEntity(Guid.NewGuid(), "Produto Atualizado");

        _mockService.Setup(s => s.UpdateAsync(product)).Returns(Task.CompletedTask);

        await _mockService.Object.UpdateAsync(product);

        _mockService.Verify(s => s.UpdateAsync(product), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ShouldBeCalledOnce()
    {
        var product = new ProductEntity(Guid.NewGuid(), "Produto Remover");

        _mockService.Setup(s => s.DeleteAsync(product)).Returns(Task.CompletedTask);

        await _mockService.Object.DeleteAsync(product);

        _mockService.Verify(s => s.DeleteAsync(product), Times.Once);
    }
}
