using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoolatyMVC.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [DisplayName("category name")]
        public string? Name { get; set; }

        [DisplayName("category created")]
        public DateTime? CreatedAt { get; set; }

        [DisplayName("category updated")]
        public DateTime? UpdatedAt { get; set; }
    }
}
