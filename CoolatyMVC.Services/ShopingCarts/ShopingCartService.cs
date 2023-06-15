using CoolatyMVC.Models;
using CoolatyMVC.Data.Repository;
using CoolatyMVC.Models.ViewModels;
using System.Linq.Expressions;

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
        public async Task<ShopingCartVM> GetAllProductsAddedToCart(string userId)
        {
            ShopingCartVM cartInfo = new()
            {
                ShoppingCart = await _repo.ShopingCart.GetAllProductsAddedToCart(userId),
                OrderHeader = new()
            };

            cartInfo.OrderHeader.OrderTotal = calculateTotalPrice(cartInfo.ShoppingCart);
            cartInfo.OrderHeader.ShippingPrice = 100;

            return cartInfo;
        }

        public async Task<ShopingCart> GetSingleCartItem(Expression<Func<ShopingCart, bool>> filter)
        {
            return await _repo.ShopingCart.GetSingleCartItem(filter);
        }

        public async Task AddToCart(ShopingCart model)
        {
            await _repo.ShopingCart.AddToCart(model);
            _repo.Save();
        }

        public void Increment(ShopingCart model, int count)
        {
            _repo.ShopingCart.Increment(model, count);
            _repo.Save();
        }

        public void Decrement(ShopingCart model, int count)
        {
            _repo.ShopingCart.Decrement(model, count);
            _repo.Save();
        }

        public void DeleteFromCart(ShopingCart model)
        {
            _repo.ShopingCart.DeleteFromCart(model);
            _repo.Save();
        }
        #endregion

        #region Private Methods
        private int calculateTotalPrice(IEnumerable<ShopingCart> shopingCart)
        {
            int totalPrice = 0;
            foreach (var product in shopingCart)
            {
                totalPrice += product.Product.Price * product.Count;
            }
            return totalPrice;
        }
        #endregion
    }
}
