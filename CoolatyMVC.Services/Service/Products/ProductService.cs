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
        public async Task<IEnumerable<ProductModel>> GetAllProducts(int pageNumber, int pageSize, string filterBy)
        {
            return await _repo.Products.GetAllProducts(pageNumber, pageSize, filterBy);
        }

        public async Task<ProductModel> GetSingleProduct(int id)
        {
            return await _repo.Products.GetSingleProduct(id);
        }
        #endregion
    }
}
