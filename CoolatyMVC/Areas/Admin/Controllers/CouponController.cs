using Microsoft.AspNetCore.Mvc;

namespace CoolatyMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CouponController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
