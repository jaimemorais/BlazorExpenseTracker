using BlazorExpenseTracker.Model;

namespace BlazorExpenseTracker.Services.Data
{
    public interface ICategoryDataService
    {
        Task<IList<Category>> GetCategoriesAsync();

    }
}
