using SaphyreDemo.Helpers;
using System.ComponentModel.DataAnnotations;

namespace SaphyreDemo.Data.Models
{
    public class OrderDescription
    {
        public Guid Id { get; set; }
        [Required]
        public string? Description { get; set; }
		[Required]
		public DropDownItem? ShippingType { get; set; } = new();
		[Required]
		[Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
		public decimal Amount { get; set; } = 0.0m;
		[Required]
		public Currency? Currency { get; set; } = new();
		public DropDownItem ProductType { get; set; } = new();
		public IEnumerable<DropDownItem> Products { get; set; } = Enumerable.Empty<DropDownItem>();
		[Required]
		[Range(0.01, double.MaxValue, ErrorMessage = "Percentage must be greater than 0")]
		public decimal TaxPercentage { get; set; } = 0.0m;
		[Required(ErrorMessage = "Date is required")]
		[DataType(DataType.Date)]
		[CustomDateValidation]
		public DateTime Date { get; set; } = DateTime.Now;
    }
}
