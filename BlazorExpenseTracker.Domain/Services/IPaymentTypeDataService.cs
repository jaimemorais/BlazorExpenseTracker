using BlazorExpenseTracker.Domain.Model;

namespace BlazorExpenseTracker.Domain.Services
{
    public interface IPaymentTypeDataService
    {
        Task<IList<PaymentType>> GetPaymentTypesAsync();

    }
}
