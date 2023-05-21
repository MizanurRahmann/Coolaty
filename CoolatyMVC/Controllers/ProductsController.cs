using CoolatyMVC.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace CoolatyWeb.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _services;
        private readonly IHttpContextAccessor _session;

        public ProductsController(ILogger<ProductsController> logger, IProductService services, IHttpContextAccessor sessionContext)
        {
            _logger = logger;
            _services = services;
            _session = sessionContext;
        }

        // GET PRODUCT
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery(Name = "search")] string search)
        {
            var data = await _services.GetAllProducts(1, 10, search);
            return View(data);
        }
    }
}
