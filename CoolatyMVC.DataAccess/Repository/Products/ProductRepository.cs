using CoolatyMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CoolatyMVC.Data.Repository.Products
{
    public class ProductRepository : IProductRepository
    {
        #region Fields
        private readonly ApplicationDbContext _db;
        #endregion

        #region Construstor
        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<ProductModel>> GetAllProducts(int pageNumber, int pageSize, string filterBy)
        {
            int offset = (pageNumber - 1) * pageSize;
            IQueryable<ProductModel> query = _db.Products.AsQueryable();

            if(!string.IsNullOrEmpty(filterBy))
            {
                query = query.Where(p => p.Name.Contains(filterBy));
            }

            IEnumerable<ProductModel> results = await query
                .OrderBy(p => p.Id)
                .Skip(offset)
                .Take(pageSize)
                .ToListAsync();
            
            return results;
        }
        #endregion
    }
}
