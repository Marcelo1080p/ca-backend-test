using System.Net.Http.Json;

namespace Billing.Application.Services;

public class ExternalBillingApiService : IExternalBillingApiService
{
    public async Task<List<BillingRequest>> GetBillingsAsync()
    {
        
        var client = new HttpClient();
        var response = await client.GetFromJsonAsync<List<BillingRequest>>("https://65c3b12439055e7482c16bca.mockapi.io/api/v1/billing");
        return response ?? new List<BillingRequest>();
    }
}
