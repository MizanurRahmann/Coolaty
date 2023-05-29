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
        public async Task<IEnumerable<ProductModel>> GetAllProducts(int pageNumber, int pageSize, string filterBy, string requestComeFrom = "Customer")
        {
            if (requestComeFrom == "Admin")
            {
                return await _repo.Products.GetAllProductsForAdmin(pageNumber, pageSize, filterBy);
            }
            return await _repo.Products.GetAllProducts(pageNumber, pageSize, filterBy);
        }

        public async Task<ProductModel> GetSingleProduct(int id)
        {
            return await _repo.Products.GetSingleProduct(id);
        }

        public async Task Create(ProductModel model)
        {
            await _repo.Products.Create(model);
            _repo.Save();
        }
        #endregion
    }
}
