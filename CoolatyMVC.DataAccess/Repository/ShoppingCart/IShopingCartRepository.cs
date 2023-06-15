using CoolatyMVC.Models;
using System.Linq.Expressions;

namespace CoolatyMVC.Data.Repository.ShopingCarts
{
    public interface IShopingCartRepository
    {
        Task<IEnumerable<ShopingCart>> GetAllProductsAddedToCart(string userId);
        Task<ShopingCart> GetSingleCartItem(Expression<Func<ShopingCart, bool>> filter);
        Task AddToCart(ShopingCart model);
        int Increment(ShopingCart shopingCart, int count);
        int Decrement(ShopingCart shopingCart, int count);
        void DeleteFromCart(ShopingCart model);
        void DeleteListOfCartItem(IEnumerable<ShopingCart> cartItems);
    }
}
