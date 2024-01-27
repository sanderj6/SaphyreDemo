namespace SaphyreDemo.Data.Models
{
    public class OrderDescription
    {
        public string? Description { get; set; }
        public DropDownItem? ShippingType { get; set; }
        public decimal Amount { get; set; }
        public Currency? Currency { get; set; }
        public IEnumerable<DropDownItem> Products { get; set; } = Enumerable.Empty<DropDownItem>();
        public decimal TaxPercentage { get; set; }
        public DateTime Date { get; set; }
    }
}
