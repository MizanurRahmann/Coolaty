using CoolatyMVC.Models;
using CoolatyMVC.Models.ViewModels;
using CoolatyMVC.Services.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoolatyMVC.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ProductsController : Controller
    {
        private readonly IService _services;
        private readonly ILogger<ProductsController> _logger;
        private readonly IHttpContextAccessor _session;

        public ProductsController(
            IService services,
            ILogger<ProductsController> logger,
            IHttpContextAccessor sessionContext)
        {
            _logger = logger;
            _services = services;
            _session = sessionContext;
        }

        // GET ALL PRODUCT
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery(Name = "category")] string search)
        {
            ProductListWithCategoryVM productListWithCategory = new()
            {
                Product = await _services.Products.GetAllProducts(1, 10, search),
                Category = await _services.Category.GetAllCategories(1, 10, "")
            };

            return View(productListWithCategory);
        }

        // GET SINGLE PRODUCT
        [HttpGet]
        public async Task<IActionResult> Details(int productId)
        {
            ShopingCart data = new()
            {
                Count = 1,
                ProductId = (int) productId,
                Product = await _services.Products.GetSingleProduct(productId)
            };

            return View("~/Areas/Customer/Views/Products/Details.cshtml", data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Details(ShopingCart shopingCart)
        {
            var claimsIdentity = (ClaimsIdentity) User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            shopingCart.AppUserId = claim.Value;

            ShopingCart cartFromDb = await _services.ShopingCart.GetSingleCartItem(claim.Value, shopingCart.ProductId);

            if(cartFromDb == null)
            {
                _services.ShopingCart.AddToCart(shopingCart);
            }
            else
            {
                _services.ShopingCart.Increment(cartFromDb, shopingCart.Count);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
