using CoolatyMVC.Models;

namespace CoolatyMVC.Data.Repository.Categories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories(int pageNumber, int pageSize, string search);
        Task<Category> GetSingleCategory(int categoryId);
        Task Create(Category model);
        void Update(Category model);
        void Delete(Category model);
    }
}
