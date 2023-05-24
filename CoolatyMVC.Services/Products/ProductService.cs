using CoolatyMVC.Models;
using CoolatyMVC.Data;
using CoolatyMVC.Data.Repository.Products;

namespace CoolatyMVC.Services.Products
{
    public class ProductService : IProductService
    {
        #region Fields
        private readonly IProductRepository _productRepository;
        #endregion

        #region Constructor
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<ProductModel>> GetAllProducts(int pageNumber, int pageSize, string filterBy)
        {
            return await _productRepository.GetAllProducts(pageNumber, pageSize, filterBy);
        }

        public async Task<ProductModel> GetSingleProduct(int id)
        {
            return await _productRepository.GetSingleProduct(id);
        }
        #endregion
    }
}
