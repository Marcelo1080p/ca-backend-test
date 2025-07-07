namespace Billing.Application.DTOs.Customer;

public class CustomerRequest
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}

public class CustomerUpdateRequest : CustomerRequest
{
    public Guid Id { get; set; }
}

public class GetCustomerRequest
{
    public Guid Id { get; set; }
}

public class CustomerResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}
