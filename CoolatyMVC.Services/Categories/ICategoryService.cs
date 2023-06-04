using CoolatyMVC.Models;

namespace CoolatyMVC.Services.Category
{
    public interface ICategoryService
    {
        Task<IEnumerable<Models.Category>> GetAllCategories(int pageNumber, int pageSize, string search);
        Task<Models.Category> GetSingleCategory(int id);
        Task Create(Models.Category model);
        void Update(Models.Category model);
    }
}
