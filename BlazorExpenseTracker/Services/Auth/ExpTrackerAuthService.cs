namespace BlazorExpenseTracker.Services.Auth
{
    public class ExpTrackerAuthService : IExpTrackerAuthService
    {

        public ExpTrackerUser? Login(string username, string password)
        {
            // TODO
            if (username == "teste")
            {
                return new ExpTrackerUser("teste", "teste", "RoleTeste");
            }

            return null;
        }


    }
}
