using BlazorExpenseTracker.Domain.Model;

namespace BlazorExpenseTracker.Domain.Services.InMemory
{
    public class CategoryDataServiceInMemory : ICategoryDataService
    {

        public async Task<IList<Category>> GetCategoriesAsync()
        {
            return await Task.FromResult(Enumerable.Range(1, 5).Select(index => new Category
            {
                Name = "Category-" + Random.Shared.Next(-20, 55)
            }).ToList());
        }

    }
}