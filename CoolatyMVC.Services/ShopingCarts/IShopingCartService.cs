using CoolatyMVC.Models;

namespace CoolatyMVC.Services.ShopingCarts
{
    public interface IShopingCartService
    {
        Task<IEnumerable<ShopingCart>> GetAllProductsAddedToCart();
        Task AddToCart(ShopingCart model);
        void UpdateCart(ShopingCart model);
        void DeleteFromCart(ShopingCart model);
    }
}
