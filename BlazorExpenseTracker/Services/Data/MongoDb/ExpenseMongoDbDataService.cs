using BlazorExpenseTracker.Model;
using BlazorExpenseTracker.Services.Data.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BlazorExpenseTracker.Services.Data.MongoDb
{
    public class ExpenseMongoDbDataService : BaseMongoDbDataService<Expense>, IExpenseDataService
    {
        public ExpenseMongoDbDataService(IOptions<ExpTrackerMongoDbSettings> expTrackerMongoDbSettings) :
            base(expTrackerMongoDbSettings, expTrackerMongoDbSettings.Value.ExpensesCollectionName)
        {
        }

        public async Task AddExpenseAsync(Expense expense)
        {
            await _collection.InsertOneAsync(expense);
        }

        public async Task<List<Expense>> GetExpensesAsync(string? userName, DateOnly startDate)
        {
            return await _collection.Find<Expense>(e => e.UserName == userName).ToListAsync();
        }
    }
}
