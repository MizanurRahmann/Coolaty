using CoolatyMVC.Models.Attributes;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoolatyMVC.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [DisplayName("category name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Category image is required.")]
        [DisplayName("category image")]
        public string? ImageUrl { get; set; }

        [NotMapped]
        [DisplayName("category image")]
        [MaxFileSize(500)]
        [AllowedFileType(new string[] { ".jpg", ".png", ".jpeg", ".webp" })]
        public IFormFile? Image { get; set; }

        [DisplayName("category created")]
        public DateTime? CreatedAt { get; set; }

        [DisplayName("category updated")]
        public DateTime? UpdatedAt { get; set; }
    }
}
