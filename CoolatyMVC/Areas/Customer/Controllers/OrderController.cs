using CoolatyMVC.Models.ViewModels;
using CoolatyMVC.Services.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoolatyMVC.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IService _services;
        private readonly ILogger<OrderController> _logger;
        private readonly IHttpContextAccessor _session;

        public OrderController(
            IService services,
            ILogger<OrderController> logger,
            IHttpContextAccessor sessionContext)
        {
            _logger = logger;
            _services = services;
            _session = sessionContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> MyOrders(int orderId)
        {
            OrderVM data = new OrderVM();

            if(orderId == null || orderId == 0)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                data.OrderItems = await _services.Order.GetMyOrders(claim.Value);
                return View(data);
            }

            data.OrderHeader = await _services.Order.GetSingleOrder(orderId);
            data.OrderDetail = await _services.OrderDetails.GetOrderDetails(orderId);

            return View("~/Areas/Customer/Views/Order/MyOrderDetails.cshtml", data);
        }
    }
}
