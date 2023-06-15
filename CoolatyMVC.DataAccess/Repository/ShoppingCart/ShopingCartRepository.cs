using CoolatyMVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CoolatyMVC.Data.Repository.ShopingCarts
{
    public class ShopingCartRepository : IShopingCartRepository
    {
        #region Fields
        private readonly ApplicationDbContext _db;
        #endregion

        #region Construstor
        public ShopingCartRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<ShopingCart>> GetAllProductsAddedToCart(string userId)
        {
            var result = _db.ShopingCarts
                .Include(item => item.Product)
                .Where(item => item.AppUserId == userId);

            return await Task.FromResult(result);
        }

        public async Task<ShopingCart> GetSingleCartItem(Expression<Func<ShopingCart, bool>> filter)
        {

            return await _db.ShopingCarts.FirstOrDefaultAsync(filter);
        }

        public async Task AddToCart(ShopingCart model)
        {
            await _db.ShopingCarts.AddAsync(model);
        }

        public int Increment(ShopingCart shopingCart, int count)
        {
            shopingCart.Count += count;
            return shopingCart.Count;
        }

        public int Decrement(ShopingCart shopingCart, int count)
        {
            shopingCart.Count -= count;
            return shopingCart.Count;
        }

        public void DeleteFromCart(ShopingCart model)
        {
            _db.ShopingCarts.Remove(model);
        }

        public void DeleteListOfCartItem(IEnumerable<ShopingCart> cartItems)
        {
            _db.ShopingCarts.RemoveRange(cartItems);
        }
        #endregion
    }
}
