using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CoolatyMVC.Models
{
    public class ShippingService
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Shipping type is required")]
        public string Feature { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ModifiedAt { get; set; } = DateTime.Now;
    }
}
