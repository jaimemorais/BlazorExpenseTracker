using BlazorExpenseTracker.Model;

namespace BlazorExpenseTracker.Services.Data
{
    public interface IExpenseDataService
    {
        Task<IList<Expense>> GetExpensesAsync(DateOnly startDate);

        Task<Expense> AddExpenseAsync(Expense expense);
    }
}
