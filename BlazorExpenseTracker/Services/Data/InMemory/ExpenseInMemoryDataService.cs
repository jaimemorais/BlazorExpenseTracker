using BlazorExpenseTracker.Model;

namespace BlazorExpenseTracker.Services.Data.InMemory
{
    public class ExpenseInMemoryDataService : IExpenseDataService
    {
        private readonly List<Expense> expenseListInMemory = new List<Expense>();

        public async Task<List<Expense>> GetExpensesAsync(string? userName, DateOnly startDate)
        {
            ////var someRandomExpenses = await Task.FromResult(Enumerable.Range(1, 3).Select(index => new Expense
            ////{
            ////    Date = startDate.AddDays(index).ToDateTime(new TimeOnly()),
            ////    Value = Random.Shared.Next(5, 200),
            ////    Category = "Category-" + Random.Shared.Next(-20, 55),
            ////    PaymentType = "PaymentType-" + Random.Shared.Next(-20, 55),
            ////    Description = "Description " + Random.Shared.Next(-20, 55),
            ////}));
            ////expenseListInMemory.AddRange(someRandomExpenses);

            return await Task.FromResult(expenseListInMemory.Where(e => e.UserName == userName).OrderByDescending(e => e.Date).ToList());
        }


        public async Task AddExpenseAsync(Expense expense)
        {
            expenseListInMemory.Add(expense);
            await Task.CompletedTask;
        }

    }
}