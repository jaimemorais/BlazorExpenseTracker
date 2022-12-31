using BlazorExpenseTracker.Model;

namespace BlazorExpenseTracker.Services.Data
{
    public interface IExpenseDataService
    {
        Task<List<Expense>> GetExpensesAsync(string? userName, DateOnly startDate);

        Task AddExpenseAsync(Expense expense);
    }
}
