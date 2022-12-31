using BlazorExpenseTracker.Services.Auth;

namespace BlazorExpenseTracker.Services.Data.InMemory
{
    public class UserDataServiceInMemory : IUserDataService
    {
        private readonly List<ExpTrackerUser> _userListInMemory = new List<ExpTrackerUser>()
        {
            new ExpTrackerUser("test", "test2", "Test User", "Admin")
        };


        public ExpTrackerUser? GetUser(string username, string password)
        {
            return _userListInMemory.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}