using CoolatyMVC.Models;
using CoolatyMVC.Models.ViewModels;
using CoolatyMVC.Services.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis;
using System.Security.Claims;

namespace CoolatyMVC.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly IService _services;
        private readonly ILogger<CartController> _logger;
        private readonly IHttpContextAccessor _session;

        public CartController(
            IService services,
            ILogger<CartController> logger,
            IHttpContextAccessor sessionContext)
        {
            _logger = logger;
            _services = services;
            _session = sessionContext;
        }

        // GET CART ITEMS
        public async Task<IActionResult> Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var cartItems = await _services.ShopingCart.GetAllProductsAddedToCart(claim.Value);

            return View(cartItems);
        }

        // INCREAMENT
        public async Task<IActionResult> Increment(int cartId)
        {
            ShopingCart cartFromDb = await _services.ShopingCart.GetSingleCartItem(u => u.Id == cartId);
            _services.ShopingCart.Increment(cartFromDb, 1);

            return RedirectToAction(nameof(Index));
        }

        // DECREAMENT
        public async Task<IActionResult> Decrement(int cartId)
        {
            ShopingCart cartFromDb = await _services.ShopingCart.GetSingleCartItem(u => u.Id == cartId);
            _services.ShopingCart.Decrement(cartFromDb, 1);

            return RedirectToAction(nameof(Index));
        }

        // DELETE
        public async Task<IActionResult> Delete(int cartId)
        {
            ShopingCart cartFromDb = await _services.ShopingCart.GetSingleCartItem(u => u.Id == cartId);
            _services.ShopingCart.DeleteFromCart(cartFromDb);
            return RedirectToAction(nameof(Index));
        }

        // Checkout
        public async Task<IActionResult> Checkout()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var cartItems = await _services.ShopingCart.GetAllProductsAddedToCart(claim.Value);

            cartItems.OrderHeader.AppUser = await _services.AppUser.GetUserInfo(claim.Value);
            cartItems.OrderHeader.Name = cartItems.OrderHeader.AppUser.Name;
            cartItems.OrderHeader.Phone = cartItems.OrderHeader.AppUser.PhoneNumber;
            cartItems.OrderHeader.Email = cartItems.OrderHeader.AppUser.Email;
            cartItems.OrderHeader.Address = cartItems.OrderHeader.AppUser.Village;
            cartItems.OrderHeader.Thana = cartItems.OrderHeader.AppUser.Thana;
            cartItems.OrderHeader.District = cartItems.OrderHeader.AppUser.Division;
            cartItems.OrderHeader.PostalCode = cartItems.OrderHeader.AppUser.PostalCode;

            return View(cartItems);
        }

        // Place Order
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(ShopingCartVM data)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var cartItems = await _services.ShopingCart.GetAllProductsAddedToCart(claim.Value);

            data.OrderHeader.PaymentStatus = "Pending";
            data.OrderHeader.OrderStatus = "Pending";
            data.OrderHeader.OrderDate = System.DateTime.Now;
            data.OrderHeader.AppUserId = claim.Value;

            ModelState.Clear();
            TryValidateModel(data);

            if (ModelState.IsValid)
            {
                await _services.Order.Create(data.OrderHeader);

                foreach (var item in cartItems.ShoppingCart)
                {
                    OrderDetail orderDetail = new()
                    {
                        ProductId = item.ProductId,
                        OrderId = data.OrderHeader.Id,
                        Price = item.Product.Price,
                        Count = item.Count
                    };

                    _services.OrderDetails.Create(orderDetail);
                }

                _services.ShopingCart.DeleteListOfCartItem(cartItems.ShoppingCart);

                TempData["success"] = "Order Placed Successfully!";
                return RedirectToAction("Index", "Cart");
            }

            return View(data);
        }
    }
}
