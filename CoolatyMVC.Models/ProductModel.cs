using CoolatyMVC.Models.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CoolatyMVC.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [DisplayName("product name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Product sub-name is required.")]
        [DisplayName("product sub-name")]
        public string? SubName { get; set; }

        [Required(ErrorMessage = "Product price is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        [DisplayName("product price")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Product compund is required.")]
        [DisplayName("product compound")]
        public string? Compound { get; set; }

        [Required(ErrorMessage = "Product proteins is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Must be greater than 0.")]
        [DisplayName("product proteins")]
        public decimal? Proteins { get; set; }

        [Required(ErrorMessage = "Product fat is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Must be greater than 0.")]
        [DisplayName("product fat")]
        public decimal? Fats { get; set; }

        [Required(ErrorMessage = "Product carbohydrates is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Must be greater than 0.")]
        [DisplayName("product carbohydrates")]
        public decimal? Carbohydrates { get; set; }

        [Required(ErrorMessage = "Product calories is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Must be greater than 0.")]
        [DisplayName("product calories")]
        public decimal? Calories { get; set; }

        [Required(ErrorMessage = "Product image is required.")]
        [DisplayName("product image")]
        public string? ImageUrl { get; set; }

        [NotMapped]
        [DisplayName("product image")]
        [MaxFileSize(500)]
        [AllowedFileType(new string[] { ".jpg", ".png", ".jpeg", ".webp" })]
        public IFormFile? Image { get; set; }

        [Required(ErrorMessage = "Product Category is required.")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual CategoryModel? Category { get; set; }

        [DisplayName("product created")]
        public DateTime? CreateDate { get; set; }

        [DisplayName("product updated")]
        public DateTime? UpdateDate { get; set; }
    }
}
