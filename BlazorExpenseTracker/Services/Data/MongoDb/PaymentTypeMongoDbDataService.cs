using BlazorExpenseTracker.Model;
using BlazorExpenseTracker.Services.Data.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BlazorExpenseTracker.Services.Data.MongoDb
{
    public class PaymentTypeMongoDbDataService : BaseMongoDbDataService<PaymentType>, IPaymentTypeDataService
    {
        public PaymentTypeMongoDbDataService(IOptions<ExpTrackerMongoDbSettings> expTrackerMongoDbSettings) :
            base(expTrackerMongoDbSettings, expTrackerMongoDbSettings.Value.PaymentTypesCollectionName)
        {
        }


        public async Task<List<PaymentType>> GetPaymentTypesAsync()
        {
            return await _collection.Aggregate<PaymentType>().ToListAsync();
        }
    }
}
