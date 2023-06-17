using CoolatyMVC.Models;

namespace CoolatyMVC.Data.Repository.Products
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts(int pageNumber, int pageSize, string filterBy);
        Task<IEnumerable<Product>> GetAllProductsForAdmin(int pageNumber, int pageSize, string filterBy);
        Task<Product> GetSingleProduct(int productId);
        Task Create(Product model);
        void Update(Product model);
        void Delete(Product model);
    }
}
