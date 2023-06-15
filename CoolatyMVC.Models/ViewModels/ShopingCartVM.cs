namespace CoolatyMVC.Models.ViewModels
{
    public class ShopingCartVM
    {
        public IEnumerable<ShopingCart>? ShoppingCart { get; set; }
        public Order OrderHeader { get; set; }
    }
}
