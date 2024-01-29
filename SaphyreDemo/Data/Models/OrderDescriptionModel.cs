namespace SaphyreDemo.Data.Models
{
    public class OrderDescription
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public DropDownItem? ShippingType { get; set; } = new();
        public decimal Amount { get; set; }
        public Currency? Currency { get; set; }
        public IEnumerable<DropDownItem> Products { get; set; } = Enumerable.Empty<DropDownItem>();
        public decimal TaxPercentage { get; set; }
        public DateTime Date { get; set; }
    }
}
