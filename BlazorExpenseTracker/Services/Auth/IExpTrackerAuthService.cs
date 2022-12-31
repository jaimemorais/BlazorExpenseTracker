namespace BlazorExpenseTracker.Services.Auth
{
    public interface IExpTrackerAuthService
    {
        Task<ExpTrackerUser?> LoginAsync(string username, string password);


    }
}
