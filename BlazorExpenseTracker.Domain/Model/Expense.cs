namespace BlazorExpenseTracker.Domain.Model
{
    public class Expense
    {
        public string UserName;


        public DateTime Date { get; set; }

        public decimal? Value { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public string PaymentType { get; set; }

    }
}