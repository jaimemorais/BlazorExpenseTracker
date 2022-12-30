using BlazorExpenseTracker.Model;

namespace BlazorExpenseTracker.Services.Data.InMemory
{
    public class PaymentTypeDataServiceInMemory : IPaymentTypeDataService
    {

        public async Task<IList<PaymentType>> GetPaymentTypesAsync()
        {
            return await Task.FromResult(Enumerable.Range(1, 5).Select(index => new PaymentType
            {
                Name = "PaymentType-" + Random.Shared.Next(-20, 55)
            }).ToList());
        }

    }
}