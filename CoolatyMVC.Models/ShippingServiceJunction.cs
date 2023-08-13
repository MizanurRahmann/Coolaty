using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoolatyMVC.Models
{
    public class ShippingServiceJunction
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Shipping")]
        public int ShippingId { get; set; }
        public Shipping Shipping { get; set; }

        [ForeignKey("ShippingService")]
        public int ServiceId { get; set; }
        public ShippingService Service { get; set; }

        public bool IsActive { get; set; }
    }
}
