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

        public async Task DeleteExpenseAsync(string expenseId)
        {
            await _collection.DeleteOneAsync(e => e.Id == expenseId);
        }

        public async Task<Expense?> GetExpenseAsync(string expenseId)
        {
            return (await _collection.FindAsync<Expense>(e => e.Id == expenseId)).FirstOrDefault();
        }

        public async Task<List<Expense>> GetExpenseListAsync(string? userName, DateOnly startDate)
        {
            return await _collection.Find<Expense>(e => e.UserName == userName).ToListAsync();
        }

        public async Task UpdateExpenseAsync(Expense expense)
        {
            var filter = Builders<Expense>.Filter.Eq(e => e.Id, expense.Id);
            var update = Builders<Expense>.Update.Set(nameof(expense.Date), expense.Date)
                                                 .Set(nameof(expense.Value), expense.Value)
                                                 .Set(nameof(expense.Description), expense.Description)
                                                 .Set(nameof(expense.Category), expense.Category)
                                                 .Set(nameof(expense.PaymentType), expense.PaymentType)
                                                 .Set(nameof(expense.UserName), expense.UserName);

            await _collection.UpdateOneAsync(filter, update);
        }
    }
}
