using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CoolatyMVC.Models.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        public string? Name { get; set; }
    }
}
