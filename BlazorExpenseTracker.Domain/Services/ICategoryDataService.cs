using BlazorExpenseTracker.Domain.Model;

namespace BlazorExpenseTracker.Domain.Services
{
    public interface ICategoryDataService
    {
        Task<IList<Category>> GetCategoriesAsync();

    }
}
