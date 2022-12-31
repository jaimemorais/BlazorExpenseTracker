using BlazorExpenseTracker.Services.Data;

namespace BlazorExpenseTracker.Services.Auth
{


    public class ExpTrackerAuthService : IExpTrackerAuthService
    {
        private readonly IUserDataService _userDataService;

        public ExpTrackerAuthService(IUserDataService userDataService)
        {
            _userDataService = userDataService;
        }

        public async Task<ExpTrackerUser?> LoginAsync(string username, string password)
        {
            // Temporarily using simple user backend
            // TODO use auth0
            return await _userDataService.GetUser(username, password);
        }


    }
}
