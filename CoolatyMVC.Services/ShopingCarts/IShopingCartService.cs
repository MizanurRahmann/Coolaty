using CoolatyMVC.Models;

namespace CoolatyMVC.Services.ShopingCarts
{
    public interface IShopingCartService
    {
        Task<IEnumerable<ShopingCart>> GetAllProductsAddedToCart();
        Task<ShopingCart> GetSingleCartItem(string userId, int productId);
        Task AddToCart(ShopingCart model);
        void Increment(ShopingCart model, int Count);
        void Decrement(ShopingCart model, int Count);
        void DeleteFromCart(ShopingCart model);
    }
}
