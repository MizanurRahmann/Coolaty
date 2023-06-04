using CoolatyMVC.Models;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IEnumerable<Models.Category>> GetAllCategories(int pageNumber, int pageSize, string search)
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

        public async Task<Models.Category> GetSingleCategory(int categoryId)
        {
            return await _db.Category.FirstOrDefaultAsync(c => c.Id == categoryId);
        }

        public async Task Create(Models.Category model)
        {
            await _db.Category.AddAsync(model);
        }

        public void Update(Models.Category model)
        {
            _db.Category.Update(model);
        }
        #endregion
    }
}
