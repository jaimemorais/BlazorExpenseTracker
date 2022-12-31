using BlazorExpenseTracker.Model;

namespace BlazorExpenseTracker.Services.Data.InMemory
{
    public class CategoryInMemoryDataService : ICategoryDataService
    {

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await Task.FromResult(Enumerable.Range(1, 5).Select(index => new Category
            {
                Name = "Category-" + Random.Shared.Next(-20, 55)
            }).ToList());
        }

    }
}