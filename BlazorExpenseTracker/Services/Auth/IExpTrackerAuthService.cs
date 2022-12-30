namespace BlazorExpenseTracker.Services.Auth
{
    public interface IExpTrackerAuthService
    {
        ExpTrackerUser? Login(string username, string password);


    }
}
