using BlazorExpenseTracker.Model;
using BlazorExpenseTracker.Services.Data.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BlazorExpenseTracker.Services.Data.MongoDb
{
    public class CategoryMongoDbDataService : BaseMongoDbDataService<Category>, ICategoryDataService
    {
        public CategoryMongoDbDataService(IOptions<ExpTrackerMongoDbSettings> expTrackerMongoDbSettings) :
            base(expTrackerMongoDbSettings, expTrackerMongoDbSettings.Value.CategoriesCollectionName)
        {
        }


        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _collection.Aggregate<Category>().ToListAsync();
        }

    }
}
