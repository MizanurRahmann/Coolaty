using CoolatyMVC.Models;

namespace CoolatyMVC.Data.Repository.ShopingCarts
{
    public interface IShopingCartRepository
    {
        Task<IEnumerable<ShopingCart>> GetAllProductsAddedToCart();
        Task AddToCart(ShopingCart model);
        void UpdateCart(ShopingCart model);
        void DeleteFromCart(ShopingCart model);
    }
}
