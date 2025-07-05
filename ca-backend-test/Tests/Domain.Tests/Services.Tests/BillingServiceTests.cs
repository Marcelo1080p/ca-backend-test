using Billing.Domain.Entities;
using FluentAssertions;
using Moq;

namespace Tests.Domain.Tests.Services.Tests
{
    public class BillingServiceTests
    {
        private readonly Mock<IBillingService> _mockService;

        public BillingServiceTests()
        {
            _mockService = new Mock<IBillingService>();
        }

        private BillingEntity CreateFakeBilling()
        {
            var customer = new CustomerEntity(
                Guid.NewGuid(),
                "Cliente Teste",
                "cliente@email.com",
                "Rua Exemplo, 123"
            );

            var product = new ProductEntity(
                Guid.NewGuid(),
                "Produto Teste"   
            );

            var billingLine = new BillingLineEntity(
                Guid.NewGuid(),
                product,
                "Descrição da linha de faturamento",
                2,
                150.00m
            );

            return new BillingEntity(
                Guid.NewGuid(),
                "INV-001",
                customer,
                DateTime.Now,
                DateTime.Now.AddDays(5),
                "BRL",
                new List<BillingLineEntity> { billingLine }
            );
        }




        [Fact]
        public async Task GetByIdAsync_ShouldReturnBillingEntity_WhenExists()
        {
            var billing = CreateFakeBilling();

            _mockService.Setup(s => s.GetByIdAsync(billing.Id)).ReturnsAsync(billing);

            var result = await _mockService.Object.GetByIdAsync(billing.Id);

            result.Should().Be(billing);
        }


        [Fact]
        public async Task GetAllAsync_ShouldReturnAllBillings()
        {
            var billings = new List<BillingEntity>
            {
                CreateFakeBilling(),
                CreateFakeBilling()
            };

            _mockService.Setup(s => s.GetAllAsync()).ReturnsAsync(billings);

            var result = await _mockService.Object.GetAllAsync();

            result.Should().BeEquivalentTo(billings);
        }

        [Fact]
        public async Task AddAsync_ShouldCallAddAsyncOnce()
        {
            var billing = CreateFakeBilling();

            await _mockService.Object.AddAsync(billing);

            _mockService.Verify(s => s.AddAsync(billing), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldCallUpdateAsyncOnce()
        {
            var billing = CreateFakeBilling();

            await _mockService.Object.UpdateAsync(billing);

            _mockService.Verify(s => s.UpdateAsync(billing), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallDeleteAsyncOnce()
        {
            var billing = CreateFakeBilling();

            await _mockService.Object.DeleteAsync(billing);

            _mockService.Verify(s => s.DeleteAsync(billing), Times.Once);
        }
    }
}
