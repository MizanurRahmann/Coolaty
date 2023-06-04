using CoolatyMVC.Models;
using CoolatyMVC.Data.Repository;

namespace CoolatyMVC.Services.Products
{
    public class ProductService : IProductService
    {
        #region Fields
        private readonly Repository _repo;
        #endregion

        #region Constructor
        public ProductService(Repository repo)
        {
            _repo = repo;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Product>> GetAllProducts(int pageNumber, int pageSize, string filterBy, string requestComeFrom = "Customer")
        {
            if (requestComeFrom == "Admin")
            {
                return await _repo.Products.GetAllProductsForAdmin(pageNumber, pageSize, filterBy);
            }
            return await _repo.Products.GetAllProducts(pageNumber, pageSize, filterBy);
        }

        public async Task<Product> GetSingleProduct(int id)
        {
            return await _repo.Products.GetSingleProduct(id);
        }

        public async Task Create(Product model)
        {
            await _repo.Products.Create(model);
            await _repo.SaveAsync();
        }

        public void Update(Product model)
        {
             _repo.Products.Update(model);
            _repo.Save();
        }
        #endregion
    }
}
