using BlazorExpenseTracker.Services.Data;

namespace BlazorExpenseTracker.Services.Auth
{

    // Temporarily using simple user backend
    // TODO use auth0
    public class ExpTrackerAuthService : IExpTrackerAuthService
    {
        private readonly IUserDataService _userDataService;

        public ExpTrackerAuthService(IUserDataService userDataService)
        {
            _userDataService = userDataService;
        }

        public ExpTrackerUser? Login(string username, string password)
        {
            return _userDataService.GetUser(username, password);
        }


    }
}
