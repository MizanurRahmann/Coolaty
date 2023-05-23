
namespace CoolatyMVC.Models.Products
{
    public class ProductMergedViewModel
    {
        public IEnumerable<ProductModel>? Products { get; set; }
        public IEnumerable<CategoryModel>? Categories { get; set; }
    }
}
