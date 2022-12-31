using System.ComponentModel.DataAnnotations;

namespace BlazorExpenseTracker.Model
{
    public class Expense : BaseModel
    {
        public string? UserName { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal? Value { get; set; }

        [Required]
        public string? Category { get; set; }

        [Required]
        public string? PaymentType { get; set; }

        [Required]
        public string? Description { get; set; }

    }
}