using BlazorExpenseTracker.Model;
using BlazorExpenseTracker.Services.Auth;

namespace BlazorExpenseTracker.Services.Data.InMemory
{
    public class UserInMemoryDataService : IUserDataService
    {
        private readonly List<User> _userListInMemory = new List<User>()
        {
            new User()
            {
                Username = "test",
                Password = "test2",
                GivenName = "Test User",
                Role = "Admin"
            }
        };


        public Task<ExpTrackerUser?> GetUser(string username, string password)
        {
            var user = _userListInMemory.FirstOrDefault(u => u.Username == username && u.Password == password);

            return Task.FromResult(user == null ? null : new ExpTrackerUser(user.Username, user.GivenName, user.Role));
        }
    }
}