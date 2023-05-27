using CoolatyMVC.Models;

namespace CoolatyMVC.Services.Category
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> GetAllCategories();
    }
}
