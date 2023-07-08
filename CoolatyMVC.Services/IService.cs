using CoolatyMVC.Services.Products;
using CoolatyMVC.Services.Categories;
using Microsoft.AspNetCore.Http;
using CoolatyMVC.Services.ShopingCarts;
using CoolatyMVC.Services.AppUsers;

namespace CoolatyMVC.Services.Service
{
    public interface IService
    {
        IProductService Products { get; }
        ICategoryService Category { get; }
        IShopingCartService ShopingCart { get; }
        IAppUserService AppUser { get; }
        Task<byte[]> GetBytes(IFormFile image);
    }
}
