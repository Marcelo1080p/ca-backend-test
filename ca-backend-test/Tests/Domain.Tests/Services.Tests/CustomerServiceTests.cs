using Billing.Domain.Entities;
using Moq;

public class ICustomerServiceTests
{
    private readonly Mock<ICustomerService> _mockService;

    public ICustomerServiceTests()
    {
        _mockService = new Mock<ICustomerService>();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnCustomer_WhenIdIsValid()
    {
        var id = Guid.NewGuid();
        var customer = new CustomerEntity(id, "João", "joao@email.com", "Rua A");
        _mockService.Setup(s => s.GetByIdAsync(id)).ReturnsAsync(customer);

        var result = await _mockService.Object.GetByIdAsync(id);

        Assert.NotNull(result);
        Assert.Equal(id, result.Id);
        Assert.Equal("João", result.Name);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnListOfCustomers()
    {
        var customers = new List<CustomerEntity>
        {
            new CustomerEntity(Guid.NewGuid(), "João", "joao@email.com", "Rua A"),
            new CustomerEntity(Guid.NewGuid(), "Maria", "maria@email.com", "Rua B")
        };

        _mockService.Setup(s => s.GetAllAsync()).ReturnsAsync(customers);

        var result = await _mockService.Object.GetAllAsync();

        Assert.NotNull(result);
        Assert.Collection(result,
            c => Assert.Equal("João", c.Name),
            c => Assert.Equal("Maria", c.Name));
    }

    [Fact]
    public async Task AddAsync_ShouldBeCalledOnce()
    {
        var customer = new CustomerEntity(Guid.NewGuid(), "Novo", "novo@email.com", "Endereço");

        _mockService.Setup(s => s.AddAsync(customer)).Returns(Task.CompletedTask);

        await _mockService.Object.AddAsync(customer);

        _mockService.Verify(s => s.AddAsync(customer), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ShouldBeCalledOnce()
    {
        var customer = new CustomerEntity(Guid.NewGuid(), "Atualizado", "atual@email.com", "Endereço");

        _mockService.Setup(s => s.UpdateAsync(customer)).Returns(Task.CompletedTask);

        await _mockService.Object.UpdateAsync(customer);

        _mockService.Verify(s => s.UpdateAsync(customer), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ShouldBeCalledOnce()
    {
        var customer = new CustomerEntity(Guid.NewGuid(), "Excluir", "del@email.com", "Endereço");

        _mockService.Setup(s => s.DeleteAsync(customer)).Returns(Task.CompletedTask);

        await _mockService.Object.DeleteAsync(customer);

        _mockService.Verify(s => s.DeleteAsync(customer), Times.Once);
    }
}
