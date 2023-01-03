using BlazorExpenseTracker.Model;

namespace BlazorExpenseTracker.Services.Data
{
    public interface IExpenseDataService
    {
        Task<List<Expense>> GetExpenseListAsync(string? userName, DateOnly startDate);

        Task<Expense?> GetExpenseAsync(string expenseId);

        Task AddExpenseAsync(Expense expense);

        Task DeleteExpenseAsync(string expenseId);

        Task UpdateExpenseAsync(Expense expense);
    }
}
