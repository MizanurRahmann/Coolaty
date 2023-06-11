using CoolatyMVC.Models;

namespace CoolatyMVC.Data.Repository.ShopingCarts
{
    public interface IShopingCartRepository
    {
        Task<IEnumerable<ShopingCart>> GetAllProductsAddedToCart();
        Task<ShopingCart> GetSingleCartItem(string userId, int productId);
        Task AddToCart(ShopingCart model);
        int Increment(ShopingCart shopingCart, int count);
        int Decrement(ShopingCart shopingCart, int count);
        void DeleteFromCart(ShopingCart model);
    }
}
