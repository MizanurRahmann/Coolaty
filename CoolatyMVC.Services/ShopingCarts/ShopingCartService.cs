using CoolatyMVC.Models;
using CoolatyMVC.Data.Repository;

namespace CoolatyMVC.Services.ShopingCarts
{
    public class ShopingCartService : IShopingCartService
    {
        #region Fields
        private readonly Repository _repo;
        #endregion

        #region Constructor
        public ShopingCartService(Repository repo)
        {
            _repo = repo;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<ShopingCart>> GetAllProductsAddedToCart()
        {
            return await _repo.ShopingCart.GetAllProductsAddedToCart();
        }

        public async Task AddToCart(ShopingCart model)
        {
            await _repo.ShopingCart.AddToCart(model);
            _repo.Save();
        }

        public void UpdateCart(ShopingCart model)
        {
            _repo.ShopingCart.UpdateCart(model);
            _repo.Save();
        }

        public void DeleteFromCart(ShopingCart model)
        {
            _repo.ShopingCart.DeleteFromCart(model);
            _repo.Save();
        }
        #endregion
    }
}
