using CoolatyMVC.Models;

namespace CoolatyMVC.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAllProducts(int pageNumber, int pageSize, string filterBy);
        Task<ProductModel> GetSingleProduct(int id);
    }
}
