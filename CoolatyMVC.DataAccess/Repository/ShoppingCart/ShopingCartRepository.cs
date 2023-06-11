using CoolatyMVC.Models;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IEnumerable<ShopingCart>> GetAllProductsAddedToCart()
        {
            var result = _db.ShopingCarts.ToList();
            return await Task.FromResult(result);
        }

        public async Task<ShopingCart> GetSingleCartItem(string userId, int productId)
        {
            return await _db.ShopingCarts.FirstOrDefaultAsync(c => c.AppUserId == userId && c.ProductId == productId);
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
        #endregion
    }
}
