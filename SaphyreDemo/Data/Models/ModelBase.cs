using System.ComponentModel.DataAnnotations;

namespace SaphyreDemo.Data.Models
{
    public class ModelBase
    {
        [Required]
        public int CompanyId { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Date Modified")]
        public DateTime? DateModified { get; set; }

        public ModelBase()
        {
            DateCreated = DateTime.UtcNow;
        }
    }
}
