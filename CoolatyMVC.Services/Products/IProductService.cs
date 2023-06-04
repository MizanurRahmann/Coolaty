using CoolatyMVC.Models;

namespace CoolatyMVC.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts(int pageNumber, int pageSize, string filterBy, string requestComeFrom="Customer");
        Task<Product> GetSingleProduct(int id);
        Task Create(Product model);
        void Update(Product model);
    }
}
