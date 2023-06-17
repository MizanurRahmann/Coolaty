namespace CoolatyMVC.Models.ViewModels
{
    public class OrderVM
    {
        public IEnumerable<Order>? OrderItems { get; set; }
        public Order OrderHeader { get; set; }
        public OrderDetail OrderDetail { get; set; }
    }
}
