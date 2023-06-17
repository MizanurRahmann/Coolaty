using CoolatyMVC.Data.Repository.Categories;
using CoolatyMVC.Data.Repository.Products;

namespace CoolatyMVC.Data.Repository
{
    public interface IRepository
    {
        ICategoryRepository Category { get; }
        IProductRepository Products { get; }
        void Save();
        Task SaveAsync();
    }
}
