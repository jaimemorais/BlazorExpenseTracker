using BlazorExpenseTracker.Model;

namespace BlazorExpenseTracker.Services.Data
{
    public interface IPaymentTypeDataService
    {
        Task<List<PaymentType>> GetPaymentTypesAsync();

    }
}
