﻿using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

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

        public ICollection<ShippingServiceJunction> ShippingFeatures { get; set; }
    }
}
