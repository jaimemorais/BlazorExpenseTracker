namespace BlazorExpenseTracker.Services.Data.MongoDb.Settings
{
    public class ExpTrackerMongoDbSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;

        public string UsersCollectionName { get; set; } = null!;
        public string ExpensesCollectionName { get; set; } = null!;
        public string PaymentTypesCollectionName { get; set; } = null!;
        public string CategoriesCollectionName { get; set; } = null!;
    }
}
