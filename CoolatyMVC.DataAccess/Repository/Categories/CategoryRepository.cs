using CoolatyMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CoolatyMVC.Data.Repository.Categories
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
        public async Task<IEnumerable<Category>> GetAllCategories(int pageNumber, int pageSize, string search)
        {
            var result = _db.Category.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(category => category.Name.Contains(search));
            }

            result = result.OrderBy(p => p.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            return await Task.FromResult(result);
        }

        public async Task<Category> GetSingleCategory(int categoryId)
        {
            return await _db.Category.FirstOrDefaultAsync(c => c.Id == categoryId);
        }

        public async Task Create(Category model)
        {
            await _db.Category.AddAsync(model);
        }

        public void Update(Category model)
        {
            _db.Category.Update(model);
        }

        public void Delete(Category model)
        {
            _db.Category.Remove(model);
        }
        #endregion
    }
}
