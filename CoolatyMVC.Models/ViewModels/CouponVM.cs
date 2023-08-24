using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CoolatyMVC.Models.ViewModels
{
    public class CouponVM
    {
        public Coupon Coupon { get; set; }
        
        [ValidateNever]
        public string ForNewUserText { get; set; }
    }
}
