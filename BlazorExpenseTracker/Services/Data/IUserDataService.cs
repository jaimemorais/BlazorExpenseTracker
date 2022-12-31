using BlazorExpenseTracker.Services.Auth;

namespace BlazorExpenseTracker.Services.Data
{
    public interface IUserDataService
    {
        Task<ExpTrackerUser?> GetUser(string username, string password);
    }
}
