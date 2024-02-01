using System.ComponentModel.DataAnnotations;

namespace SaphyreDemo.Data.Models
{
    public class DropDownItem
    {
        public Guid Id { get; set; }
		[Required]
		public string Name { get; set; } = null!;
		public string SecondaryName { get; set; } = null!;
    }
}
