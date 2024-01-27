using System.ComponentModel.DataAnnotations;

namespace SaphyreDemo.Data.Models
{
    public class YourModel
    {
        [Required]
        public string FreeText { get; set; }
        public string SingleSelect { get; set; }
        public decimal Amount { get; set; }
        [Required]
        public string Currency { get; set; }
        public IEnumerable<string> MultiSelect { get; set; }
        public decimal Percentage { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
