using CoolatyMVC.Models;
using CoolatyMVC.Data.Repository.Category;

namespace CoolatyMVC.Services.Category
{
    public class CategoryService : ICategoryService
    {
        #region Fields
        private readonly ICategoryRepository _categoryRepository;
        #endregion

        #region Constructor
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<CategoryModel>> GetAllCategories()
        {
            return await _categoryRepository.GetAllCategories();
        }
        #endregion
    }
}
