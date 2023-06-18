namespace CoolatyMVC.Models.ViewModels
{
    public class ProductListWithCategoryVM
    {
        public IEnumerable<Product>? Product { get; set; }
        public IEnumerable<Category>? Category { get; set; }
    }
}
