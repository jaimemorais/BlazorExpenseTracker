using BlazorExpenseTracker.Domain.Model;

namespace BlazorExpenseTracker.Domain.Services
{
    public interface IExpenseDataService
    {
        Task<IList<Expense>> GetExpensesAsync(DateOnly startDate);

        Task<Expense> AddExpenseAsync(Expense expense);
    }
}
