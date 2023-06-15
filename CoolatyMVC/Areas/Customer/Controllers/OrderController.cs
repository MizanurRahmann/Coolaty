using Microsoft.AspNetCore.Mvc;

namespace CoolatyMVC.Areas.Customer.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
