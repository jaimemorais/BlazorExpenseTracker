using BlazorExpenseTracker.Model;

namespace BlazorExpenseTracker.Services.Data.InMemory
{
    public class PaymentTypeInMemoryDataService : IPaymentTypeDataService
    {

        public async Task<List<PaymentType>> GetPaymentTypesAsync()
        {
            return await Task.FromResult(Enumerable.Range(1, 5).Select(index => new PaymentType
            {
                Name = "PaymentType-" + Random.Shared.Next(-20, 55)
            }).ToList());
        }

    }
}