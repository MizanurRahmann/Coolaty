using System.ComponentModel.DataAnnotations;

namespace CoolatyMVC.Models
{
    public class Coupon
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Coupon name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Coupon code is required")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Coupon type is required")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Coupon discount amount is required")]
        public int DiscountAmount { get; set; }

        public string Status { get; set; }
        public int MinimumCost { get; set; }
        public int MinimumItem { get; set; }
        public bool ForNewUser { get; set; }

        [Required(ErrorMessage = "Coupon expire date is required")]
        public DateTime ExpireDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ModifiedAt { get; set; } = DateTime.Now;
    }
}
