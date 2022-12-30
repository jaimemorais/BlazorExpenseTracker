using BlazorExpenseTracker.Model;

namespace BlazorExpenseTracker.Services.Data.InMemory
{
    public class ExpenseDataServiceInMemory : IExpenseDataService
    {
        private readonly List<Expense> expenseListInMemory = new List<Expense>();

        public async Task<IList<Expense>> GetExpensesAsync(DateOnly startDate)
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

            return await Task.FromResult(expenseListInMemory.OrderByDescending(e => e.Date).ToList());
        }


        public async Task<Expense> AddExpenseAsync(Expense expense)
        {
            expenseListInMemory.Add(expense);
            return await Task.FromResult(expense);
        }

    }
}