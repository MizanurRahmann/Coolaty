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
        public async Task<IEnumerable<Product>> GetAllProducts(int pageNumber, int pageSize, string filterBy)
        {
            var result = _db.Products.AsQueryable();

            if (!string.IsNullOrEmpty(filterBy))
            {
                result = result.Where(product => product.Category.Name == filterBy);
            }

            result = result.OrderBy(p => p.CreateDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<Product>> GetAllProductsForAdmin(int pageNumber, int pageSize, string filterBy)
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

        public async Task<Product> GetSingleProduct(int productId)
        {
            return await _db.Products.Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == productId);
        }

        public async Task Create(Product model)
        {
            await _db.Products.AddAsync(model);
        }

        public void Update(Product model)
        {
            _db.Products.Update(model);
        }

        public void Delete(Product model)
        {
            _db.Products.Remove(model);
        }
        #endregion
    }
}
