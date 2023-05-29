using Azure;
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
            var result = _db.Products
                .Where(p => p.Category.Name == filterBy)
                .OrderBy(p => p.Name)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<ProductModel>> GetAllProductsForAdmin(int pageNumber, int pageSize, string filterBy)
        {
            var result = _db.Products.AsQueryable();

            if (!string.IsNullOrEmpty(filterBy))
            {
                result = result.Where(product => product.Name.Contains(filterBy));
            }

            result = result.OrderBy(p => p.CreateDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            return await Task.FromResult(result);
        }

        public async Task<ProductModel> GetSingleProduct(int productId)
        {
            return await _db.Products.FirstOrDefaultAsync(p => p.Id == productId);
        }

        public async Task Create(ProductModel model)
        {
            await _db.Products.AddAsync(model);
        }
        #endregion
    }
}
