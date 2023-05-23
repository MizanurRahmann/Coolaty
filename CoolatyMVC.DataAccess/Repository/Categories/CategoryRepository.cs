using CoolatyMVC.Models;

namespace CoolatyMVC.Data.Repository.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        #region Fields
        private readonly ApplicationDbContext _db;
        #endregion

        #region Construstor
        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<CategoryModel>> GetAllCategories()
        {
            var result = _db.Category.Select(c => new CategoryModel {
                Id = c.Id,
                Name = c.Name,
            });

            return await Task.FromResult(result);
        }
        #endregion
    }
}
