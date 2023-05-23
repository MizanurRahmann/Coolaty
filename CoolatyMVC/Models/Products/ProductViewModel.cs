using System.ComponentModel.DataAnnotations;

namespace CoolatyMVC.Models.Products
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Product sub-name is required.")]
        public string? SubName { get; set; }

        [Required(ErrorMessage = "Product price is required.")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Product compund is required.")]
        public string? Compound { get; set; }

        [Required(ErrorMessage = "Product proteins is required.")]
        public decimal? Proteins { get; set; }

        [Required(ErrorMessage = "Product fat is required.")]
        public decimal? Fats { get; set; }

        [Required(ErrorMessage = "Product carbohydrates is required.")]
        public decimal? Carbohydrates { get; set; }

        [Required(ErrorMessage = "Product calories is required.")]
        public decimal? Calories { get; set; }

        [Required(ErrorMessage = "Product image is required.")]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Product category is required.")]
        public string? CategoryName { get; set; }
    }
}
