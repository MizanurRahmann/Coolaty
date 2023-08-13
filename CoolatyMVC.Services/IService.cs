using CoolatyMVC.Services.Products;
using CoolatyMVC.Services.Categories;
using Microsoft.AspNetCore.Http;
using CoolatyMVC.Services.ShopingCarts;
using CoolatyMVC.Services.AppUsers;
using CoolatyMVC.Services.Orders;
using CoolatyMVC.Services.OrderDetails;
using CoolatyMVC.Services.Shippings;

namespace CoolatyMVC.Services.Service
{
    public interface IService
    {
        IProductService Products { get; }
        ICategoryService Category { get; }
        IShopingCartService ShopingCart { get; }
        IOrderService Order { get; }
        IOrderDetailsService OrderDetails { get; }
        IAppUserService AppUser { get; }
        IShippingServices ShippingService { get; }
        Task<byte[]> GetBytes(IFormFile image);
    }
}
