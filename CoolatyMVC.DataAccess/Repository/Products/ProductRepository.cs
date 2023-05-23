using CoolatyMVC.Models;

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
            var result = _db.Products
                .Where(p => p.Category.Name == filterBy)
                .OrderBy(p => p.Name)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            return await Task.FromResult(result);
        }
        #endregion
    }
}
