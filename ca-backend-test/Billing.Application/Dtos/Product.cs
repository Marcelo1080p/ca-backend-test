namespace Billing.Application.DTOs.Product;

public class ProductRequest
{
    
    public string Name { get; set; } = string.Empty;
}

public class ProductCreateRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}


public class ProductUpdateRequest : ProductRequest
{
    public Guid Id { get; set; }
}

public class ProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
