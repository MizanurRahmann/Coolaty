using CoolatyMVC.Models;

namespace CoolatyMVC.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAllProducts(int pageNumber, int pageSize, string filterBy, string requestComeFrom="Customer");
        Task<ProductModel> GetSingleProduct(int id);
        Task Create(ProductModel model);
    }
}
