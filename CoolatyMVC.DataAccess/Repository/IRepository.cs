using CoolatyMVC.Data.Repository.AppUsers;
using CoolatyMVC.Data.Repository.Categories;
using CoolatyMVC.Data.Repository.OrderDetails;
using CoolatyMVC.Data.Repository.Orders;
using CoolatyMVC.Data.Repository.Products;
using CoolatyMVC.Data.Repository.ShopingCarts;

namespace CoolatyMVC.Data.Repository
{
    public interface IRepository
    {
        ICategoryRepository Category { get; }
        IProductRepository Products { get; }
        IShopingCartRepository ShopingCart { get; }
        IOrderRepository Order { get; }
        IOrderDetailsRepository OrderDetail { get; }
        IAppUserRepository AppUser { get; }
        void Save();
        Task SaveAsync();
    }
}
