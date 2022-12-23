using BlazorExpenseTracker.Domain.Model;

namespace BlazorExpenseTracker.Domain.Services
{
    public class ExpensesDataService
    {

        public Task<Expense[]> GetExpenses(DateOnly startDate)
        {
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new Expense
            {
                Date = startDate.AddDays(index).ToDateTime(new TimeOnly()),
                Value = Random.Shared.Next(5, 200),
                Category = "Category-" + Random.Shared.Next(-20, 55),
                PaymentType = "PaymentType-" + Random.Shared.Next(-20, 55),
                Description = "Description " + Random.Shared.Next(-20, 55),
            }).ToArray());
        }
    }
}