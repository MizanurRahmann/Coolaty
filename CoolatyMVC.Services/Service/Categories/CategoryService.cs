using CoolatyMVC.Models;
using CoolatyMVC.Data.Repository.Category;
using CoolatyMVC.Data.Repository;

namespace CoolatyMVC.Services.Category
{
    public class CategoryService : ICategoryService
    {
        #region Fields
        private readonly Repository _repo;
        #endregion

        #region Constructor
        public CategoryService(Repository repo)
        {
            _repo = repo;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<CategoryModel>> GetAllCategories()
        {
            return await _repo.Category.GetAllCategories();
        }
        #endregion
    }
}
