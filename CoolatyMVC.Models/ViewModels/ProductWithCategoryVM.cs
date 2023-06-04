namespace CoolatyMVC.Models.ViewModels
{
    public class ProductWithCategoryVM
    {
        public Product Product { get; set; }
        public IEnumerable<Category>? Category { get; set; }
    }
}
