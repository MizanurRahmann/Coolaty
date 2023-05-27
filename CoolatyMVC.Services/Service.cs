using CoolatyMVC.Services.Products;
using CoolatyMVC.Services.Category;
using CoolatyMVC.Data.Repository;

namespace CoolatyMVC.Services.Service
{
    public class Service : IService
    {
        private readonly Repository _repo;
        public ICategoryService Category { get; private set; }
        public IProductService Products { get; private set; }

        public Service(Repository repo)
        {
            _repo = repo;
            Category = new CategoryService(_repo);
            Products = new ProductService(_repo);
        }
    }
}
