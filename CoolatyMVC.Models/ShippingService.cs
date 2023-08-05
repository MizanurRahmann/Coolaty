using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CoolatyMVC.Models
{
    public class ShippingService
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Shipping type is required")]
        public string Feature { get; set; }

        public ICollection<ShippingServiceJunction> ShippingFeatures { get; set; }
    }
}
