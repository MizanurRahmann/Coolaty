using CoolatyMVC.Services.Products;
using CoolatyMVC.Services.Category;

namespace CoolatyMVC.Services.Service
{
    public interface IService
    {
        IProductService Products { get; }
        ICategoryService Category { get; }
    }
}
