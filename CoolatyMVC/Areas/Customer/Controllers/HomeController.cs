using CoolatyMVC.Models;
using CoolatyMVC.Models.ViewModels;
using CoolatyMVC.Services.Service;
using Microsoft.AspNetCore.Mvc;

namespace CoolatyMVC.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IService _services;

        public HomeController(
            ILogger<HomeController> logger,
            IService services)
        {
            _logger = logger;
            _services = services;
        }

        public async Task<IActionResult> Index()
        {
            ProductListWithCategoryVM productListWithCategory = new()
            {
                Product = await _services.Products.GetAllProducts(1, 10, ""),
                Category = await _services.Category.GetAllCategories(1, 10, "")
            };

            return View(productListWithCategory);
        }
    }
}