    using CoolatyMVC.Data.Repository.Categories;
using CoolatyMVC.Data.Repository.Products;

namespace CoolatyMVC.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Products { get; private set; }

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Products = new ProductRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

    }
}
