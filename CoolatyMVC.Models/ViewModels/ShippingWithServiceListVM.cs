using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CoolatyMVC.Models.ViewModels
{
    public class ShippingWithServiceListVM
    {
        public Shipping Shipping { get; set; }
        
        [ValidateNever]
        public IEnumerable<ShippingServiceVM> ShippingServices { get; set; }
    }
}
