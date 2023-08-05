using Microsoft.AspNetCore.Mvc;

namespace CoolatyMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ShippingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }
    }
}
