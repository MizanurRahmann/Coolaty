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

        public async Task AddToCart(ShopingCart model)
        {
            await _db.ShopingCarts.AddAsync(model);
        }

        public void UpdateCart(ShopingCart model)
        {
            _db.ShopingCarts.Update(model);
        }

        public void DeleteFromCart(ShopingCart model)
        {
            _db.ShopingCarts.Remove(model);
        }
        #endregion
    }
}
