public interface IExternalBillingApiService
{
    Task<List<BillingRequest>> GetBillingsAsync();
}