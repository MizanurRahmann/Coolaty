using CoolatyMVC.Models;

namespace CoolatyMVC.Data.Repository.Category
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Models.Category>> GetAllCategories(int pageNumber, int pageSize, string search);
        Task<Models.Category> GetSingleCategory(int categoryId);
        Task Create(Models.Category model);
        void Update(Models.Category model);
    }
}
