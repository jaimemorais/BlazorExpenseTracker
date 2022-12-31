using BlazorExpenseTracker.Model;
using BlazorExpenseTracker.Services.Data.MongoDb.Settings;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BlazorExpenseTracker.Services.Data.MongoDb
{
    public class PaymentTypeMongoDbDataService : BaseMongoDbDataService<PaymentType>, IPaymentTypeDataService
    {
        private readonly IMemoryCache _memoryCache;

        public PaymentTypeMongoDbDataService(IOptions<ExpTrackerMongoDbSettings> expTrackerMongoDbSettings, IMemoryCache memoryCache) :
            base(expTrackerMongoDbSettings, expTrackerMongoDbSettings.Value.PaymentTypesCollectionName)
        {
            _memoryCache = memoryCache;
        }


        public async Task<List<PaymentType>> GetPaymentTypesAsync()
        {
            const string CACHE_KEY = "paymentTypesCache";
            var cachedList = (List<PaymentType>?)_memoryCache.Get(CACHE_KEY);
            if (cachedList != null)
            {
                return cachedList;
            }

            var dbList = await _collection.Aggregate<PaymentType>().ToListAsync();

            _memoryCache.Set(CACHE_KEY, dbList);

            return dbList;
        }
    }
}
