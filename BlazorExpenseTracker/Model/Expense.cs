using System.ComponentModel.DataAnnotations;

namespace BlazorExpenseTracker.Model
{
    public class Expense : BaseModel
    {
        public string? UserName { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:#,####}")]
        public decimal? Value { get; set; }

        [Required]
        public string? Category { get; set; }

        [Required]
        public string? PaymentType { get; set; }

        [Required]
        public string? Description { get; set; }

    }
}