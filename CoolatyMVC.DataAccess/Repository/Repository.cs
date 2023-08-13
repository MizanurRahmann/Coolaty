using CoolatyMVC.Data.Repository.AppUsers;
using CoolatyMVC.Data.Repository.Categories;
using CoolatyMVC.Data.Repository.OrderDetails;
using CoolatyMVC.Data.Repository.Orders;
using CoolatyMVC.Data.Repository.Products;
using CoolatyMVC.Data.Repository.Shippings;
using CoolatyMVC.Data.Repository.ShopingCarts;

namespace CoolatyMVC.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Products { get; private set; }
        public IShopingCartRepository ShopingCart { get; private set; }
        public IOrderRepository Order { get; private set; }
        public IOrderDetailsRepository OrderDetail { get; private set; }
        public IAppUserRepository AppUser { get; private set;  }
        public IShippingRepository Shipping { get; private set; }

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Products = new ProductRepository(_db);
            ShopingCart = new ShopingCartRepository(_db);
            Order = new OrderRepository(_db);
            OrderDetail = new OrderDetailsRepository(_db);
            AppUser = new AppUserRepository(_db);
            Shipping = new ShippingRepository(_db);
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
