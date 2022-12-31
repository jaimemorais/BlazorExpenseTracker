using BlazorExpenseTracker.Model;
using BlazorExpenseTracker.Services.Auth;
using BlazorExpenseTracker.Services.Data.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BlazorExpenseTracker.Services.Data.MongoDb
{
    public class UserMongoDbDataService : BaseMongoDbDataService<User>, IUserDataService
    {
        public UserMongoDbDataService(IOptions<ExpTrackerMongoDbSettings> expTrackerMongoDbSettings) :
            base(expTrackerMongoDbSettings, expTrackerMongoDbSettings.Value.UsersCollectionName)
        {
        }


        public async Task<ExpTrackerUser?> GetUser(string username, string password)
        {
            var user = (await _mongoCollection.FindAsync(u => u.Username == username && u.Password == password)).FirstOrDefault();

            return user == null ? null : new ExpTrackerUser(user.Username, user.GivenName, user.Role);
        }

    }
}
