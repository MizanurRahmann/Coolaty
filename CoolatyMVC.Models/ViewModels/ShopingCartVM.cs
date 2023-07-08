namespace CoolatyMVC.Models.ViewModels
{
    public class ShopingCartVM
    {
        public IEnumerable<ShopingCart>? ShoppingCart { get; set; }
        public int TotalPrice { get; set; }
        public int ShippingCost { get; set; }
    }
}
