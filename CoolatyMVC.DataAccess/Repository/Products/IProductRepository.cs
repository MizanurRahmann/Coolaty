using CoolatyMVC.Models;

namespace CoolatyMVC.Data.Repository.Products
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductModel>> GetAllProducts(int pageNumber, int pageSize, string filterBy);
        Task<ProductModel> GetSingleProduct(int productId);
    }
}
