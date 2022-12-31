namespace BlazorExpenseTracker.Model
{
    public class User : BaseModel
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string GivenName { get; set; } = string.Empty;
    }
}