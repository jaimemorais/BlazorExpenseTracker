using BlazorExpenseTracker.Model;
using BlazorExpenseTracker.Services.Data.MongoDb.Settings;
using Microsoft.Extensions.Options;

namespace BlazorExpenseTracker.Services.Data.MongoDb
{
    public class PaymentTypeMongoDbDataService : BaseMongoDbDataService<PaymentType>, IPaymentTypeDataService
    {
        public PaymentTypeMongoDbDataService(IOptions<ExpTrackerMongoDbSettings> expTrackerMongoDbSettings) :
            base(expTrackerMongoDbSettings, expTrackerMongoDbSettings.Value.PaymentTypesCollectionName)
        {
        }


        public Task<IList<PaymentType>> GetPaymentTypesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
