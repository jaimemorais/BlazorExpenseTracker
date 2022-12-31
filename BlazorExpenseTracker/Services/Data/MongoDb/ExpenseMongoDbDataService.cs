using BlazorExpenseTracker.Model;
using BlazorExpenseTracker.Services.Data.MongoDb.Settings;
using Microsoft.Extensions.Options;

namespace BlazorExpenseTracker.Services.Data.MongoDb
{
    public class ExpenseMongoDbDataService : BaseMongoDbDataService<Expense>, IExpenseDataService
    {
        public ExpenseMongoDbDataService(IOptions<ExpTrackerMongoDbSettings> expTrackerMongoDbSettings) :
            base(expTrackerMongoDbSettings, expTrackerMongoDbSettings.Value.ExpensesCollectionName)
        {
        }

        public Task<Expense> AddExpenseAsync(Expense expense)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Expense>> GetExpensesAsync(DateOnly startDate)
        {
            throw new NotImplementedException();
        }
    }
}
