using BlazorExpenseTracker.Services.Data.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Security.Authentication;

namespace BlazorExpenseTracker.Services.Data.MongoDb
{
    public abstract class BaseMongoDbDataService<T>
    {
        private readonly IMongoDatabase _mongoDatabase;
        private readonly string _collectionName;

        protected BaseMongoDbDataService(IOptions<ExpTrackerMongoDbSettings> expTrackerMongoDbSettings, string collectionName)
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(expTrackerMongoDbSettings.Value.ConnectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);
            _mongoDatabase = mongoClient.GetDatabase(expTrackerMongoDbSettings.Value.DatabaseName);

            _collectionName = collectionName;
        }

        protected IMongoCollection<T> _collection => _mongoDatabase.GetCollection<T>(_collectionName);

    }
}
