using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CoolatyMVC.Models
{
    public class Shipping
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Shipping type is required")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Shipping price is required")]
        public int Price { get; set; }
        
        [Required(ErrorMessage = "Shipping description is required")]
        public string Description { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ModifiedAt { get; set; } = DateTime.Now;
    }
}
