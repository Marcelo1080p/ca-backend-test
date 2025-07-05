using Billing.Domain.Entities;

namespace Tests.Domain.Tests.Entities.Tests;

public class CustomerTests
{
    [Fact]
    public void Should_Create_Customer_With_Valid_Data()
    {
       var id = Guid.NewGuid();
        var name = "João";
        var email = "joao@example.com";
        var address = "Rua X, 123";

        
        var customer = new CustomerEntity(id, name, email, address);

        
        Assert.Equal(name, customer.Name);
        Assert.Equal(email, customer.Email);
        Assert.Equal(address, customer.Address);
    }

}
