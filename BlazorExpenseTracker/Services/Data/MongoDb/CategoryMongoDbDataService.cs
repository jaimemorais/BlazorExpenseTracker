using BlazorExpenseTracker.Model;
using BlazorExpenseTracker.Services.Data.MongoDb.Settings;
using Microsoft.Extensions.Options;

namespace BlazorExpenseTracker.Services.Data.MongoDb
{
    public class CategoryMongoDbDataService : BaseMongoDbDataService<Category>, ICategoryDataService
    {
        public CategoryMongoDbDataService(IOptions<ExpTrackerMongoDbSettings> expTrackerMongoDbSettings) :
            base(expTrackerMongoDbSettings, expTrackerMongoDbSettings.Value.CategoriesCollectionName)
        {
        }


        public Task<IList<Category>> GetCategoriesAsync()
        {
            throw new NotImplementedException();
        }

    }
}
