using CoolatyMVC.Models;
using CoolatyMVC.Models.ViewModels;
using System.Linq.Expressions;

namespace CoolatyMVC.Services.ShopingCarts
{
    public interface IShopingCartService
    {
        Task<ShopingCartVM> GetAllProductsAddedToCart(string userId);
        Task<ShopingCart> GetSingleCartItem(Expression<Func<ShopingCart, bool>> filter);
        Task AddToCart(ShopingCart model);
        void Increment(ShopingCart model, int Count);
        void Decrement(ShopingCart model, int Count);
        void DeleteFromCart(ShopingCart model);
    }
}
