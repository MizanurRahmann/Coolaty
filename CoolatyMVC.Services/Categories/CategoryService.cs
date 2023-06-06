using CoolatyMVC.Models;
using CoolatyMVC.Data.Repository;

namespace CoolatyMVC.Services.Categories
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
        public async Task<IEnumerable<Category>> GetAllCategories(int pageNumber, int pageSize, string search)
        {
            return await _repo.Category.GetAllCategories(pageNumber, pageSize, search);
        }

        public async Task<Category> GetSingleCategory(int id)
        {
            return await _repo.Category.GetSingleCategory(id);
        }

        public async Task Create(Category model)
        {
            await _repo.Category.Create(model);
            _repo.Save();
        }

        public void Update(Category model)
        {
            _repo.Category.Update(model);
            _repo.Save();
        }

        public void Delete(Category model)
        {
            _repo.Category.Delete(model);
            _repo.Save();
        }
        #endregion
    }
}
