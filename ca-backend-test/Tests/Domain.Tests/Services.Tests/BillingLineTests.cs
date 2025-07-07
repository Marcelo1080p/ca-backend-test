using Billing.Domain.Entities;
using Moq;

public class IBillingLineServiceTests
{
    private readonly Mock<IBillingLineService> _mockService;

    public IBillingLineServiceTests()
    {
        _mockService = new Mock<IBillingLineService>();
    }

    private BillingLineEntity CreateBillingLine()
    {
        var product = new ProductEntity(Guid.NewGuid(), "Notebook");
        return new BillingLineEntity(Guid.NewGuid(), product, "BILL123", 2, 3000m);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnBillingLine_WhenIdIsValid()
    {
        var id = Guid.NewGuid();
        var billingLine = CreateBillingLine();

        _mockService.Setup(s => s.GetByIdAsync(id)).ReturnsAsync(billingLine);

        var result = await _mockService.Object.GetByIdAsync(id);

        Assert.NotNull(result);
        Assert.Equal(2, result.Quantity);
        Assert.Equal(3000m, result.UnitPrice);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnBillingLines()
    {
        var lines = new List<BillingLineEntity>
        {
            CreateBillingLine(),
            CreateBillingLine()
        };

        _mockService.Setup(s => s.GetAllAsync()).ReturnsAsync(lines);

        var result = await _mockService.Object.GetAllAsync();

        Assert.NotNull(result);
        Assert.Equal(2, ((List<BillingLineEntity>)result).Count);
    }

    [Fact]
    public async Task AddAsync_ShouldCallOnce()
    {
        var billingLine = CreateBillingLine();

        _mockService.Setup(s => s.AddAsync(billingLine)).Returns(Task.CompletedTask);

        await _mockService.Object.AddAsync(billingLine);

        _mockService.Verify(s => s.AddAsync(billingLine), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ShouldCallOnce()
    {
        var billingLine = CreateBillingLine();

        _mockService.Setup(s => s.UpdateAsync(billingLine)).Returns(Task.CompletedTask);

        await _mockService.Object.UpdateAsync(billingLine);

        _mockService.Verify(s => s.UpdateAsync(billingLine), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallOnce()
    {
        var billingLine = CreateBillingLine();

        _mockService.Setup(s => s.DeleteAsync(billingLine)).Returns(Task.CompletedTask);

        await _mockService.Object.DeleteAsync(billingLine);

        _mockService.Verify(s => s.DeleteAsync(billingLine), Times.Once);
    }
}
