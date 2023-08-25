using CoolatyMVC.Models;
using CoolatyMVC.Services.Service;
using Microsoft.AspNetCore.Mvc;

namespace CoolatyMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrdersController : Controller
    {
        #region Filelds
        private readonly IService _services;
        private readonly ILogger<OrdersController> _logger;
        private readonly IHttpContextAccessor _session;
        #endregion

        #region Constructor
        public OrdersController(
            IService services,
            ILogger<OrdersController> logger,
            IHttpContextAccessor sessionContext)
        {
            _logger = logger;
            _services = services;
            _session = sessionContext;
        }
        #endregion

        #region Methods
        public async Task<IActionResult> Index([FromQuery(Name = "search")] string search, [FromQuery(Name = "type")] string type)
        {
            var orders = await _services.Order.GetAllOrders(1, 100, search, type);
            return View(orders);
        }

        public IActionResult Update()
        {
            return View();
        }
        #endregion
    }
}
