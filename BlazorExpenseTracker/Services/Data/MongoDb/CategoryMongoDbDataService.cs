using BlazorExpenseTracker.Model;
using BlazorExpenseTracker.Services.Data.MongoDb.Settings;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BlazorExpenseTracker.Services.Data.MongoDb
{
    public class CategoryMongoDbDataService : BaseMongoDbDataService<Category>, ICategoryDataService
    {
        private readonly IMemoryCache _memoryCache;


        public CategoryMongoDbDataService(IOptions<ExpTrackerMongoDbSettings> expTrackerMongoDbSettings, IMemoryCache memoryCache) :
            base(expTrackerMongoDbSettings, expTrackerMongoDbSettings.Value.CategoriesCollectionName)
        {
            _memoryCache = memoryCache;
        }


        public async Task<List<Category>> GetCategoriesAsync()
        {
            const string CACHE_KEY = "categoriesCache";
            var cachedList = (List<Category>?)_memoryCache.Get(CACHE_KEY);
            if (cachedList != null)
            {
                return cachedList;
            }

            var dbList = await _collection.Aggregate<Category>().ToListAsync();

            _memoryCache.Set(CACHE_KEY, dbList);

            return dbList;
        }

    }
}
