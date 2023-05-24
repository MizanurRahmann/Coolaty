using CoolatyMVC.Models;
using CoolatyMVC.Models.Category;
using CoolatyMVC.Models.Products;
using CoolatyMVC.Services.Category;
using CoolatyMVC.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace CoolatyWeb.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _prodServices;
        private readonly ICategoryService _catServices;
        private readonly IHttpContextAccessor _session;

        public ProductsController(
            ILogger<ProductsController> logger, 
            IProductService prodServices,
            ICategoryService catServices,
            IHttpContextAccessor sessionContext)
        {
            _logger = logger;
            _prodServices = prodServices;
            _catServices = catServices;
            _session = sessionContext;
        }

        // GET ALL PRODUCT
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery(Name = "category")] string search)
        {
            var productData = await _prodServices.GetAllProducts(1, 10, search);
            return View(productData);
        }

        // GET SINGLE PRODUCT
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            ProductModel data = await _prodServices.GetSingleProduct(id);
            return View("~/Views/Products/Details.cshtml", data);
        }
    }
}
