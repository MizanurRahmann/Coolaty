using CoolatyMVC.Models;

namespace CoolatyMVC.Data.Repository.Category
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryModel>> GetAllCategories();
    }
}
