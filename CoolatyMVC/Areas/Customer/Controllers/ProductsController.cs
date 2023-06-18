using CoolatyMVC.Models;
using CoolatyMVC.Models.ViewModels;
using CoolatyMVC.Services.Service;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Details(int id)
        {
            Product data = await _services.Products.GetSingleProduct(id);
            return View("~/Areas/Customer/Views/Products/Details.cshtml", data);
        }
    }
}
