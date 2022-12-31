using BlazorExpenseTracker.Services.Auth;

namespace BlazorExpenseTracker.Services.Data
{
    public interface IUserDataService
    {
        ExpTrackerUser? GetUser(string username, string password);
    }
}
