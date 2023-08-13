using CoolatyMVC.Models;
using CoolatyMVC.Models.ViewModels;
using CoolatyMVC.Services.Service;
using Microsoft.AspNetCore.Mvc;

namespace CoolatyMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ShippingController : Controller
    {
        #region Filelds
        private readonly IService _services;
        private readonly ILogger<ShippingController> _logger;
        private readonly IHttpContextAccessor _session;
        #endregion

        #region Constructor
        public ShippingController(
            IService services,
            ILogger<ShippingController> logger,
            IHttpContextAccessor sessionContext)
        {
            _logger = logger;
            _services = services;
            _session = sessionContext;
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var shipping = await _services.ShippingService.GetAllShippingTypes();
            return View(shipping);
        }

        [HttpGet]
        public async Task<IActionResult> Services()
        {
            var shippingService = await _services.ShippingService.GetAllShippingServices();
            return View(shippingService);
        }

        [HttpGet]
        public async Task<IActionResult> UpsertShipping(int? id)
        {
            var service = new ShippingService();

            if (id == null || id == 0)
            {
                return View(service);
            }

            service = await _services.ShippingService.GetSingleShippingService((int)id);
            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateShippingService(ShippingService model)
        {
            if (ModelState.IsValid)
            {
                var domainModel = new ShippingService()
                {
                    Id = model.Id,
                    Feature = model.Feature,
                };

                if (model.Id == 0)
                {
                    await _services.ShippingService.CreateShippingService(domainModel);
                    TempData["success"] = "Service Added Successfully!";
                }
                else
                {
                    _services.ShippingService.UpdateShippingService(domainModel);
                    TempData["success"] = "Service Updated Successfully!";
                }

                return RedirectToAction("Services");
            }

            TempData["success"] = "Something Went Wrong!";
            return View("Services");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            ShippingService data = await _services.ShippingService.GetSingleShippingService(id);

            if (data != null)
            {
                _services.ShippingService.DeleteShippingService(data);
                TempData["success"] = "Deleted Successfully!";
                return RedirectToAction("Services");
            }

            TempData["error"] = "Something went wrong!";
            return RedirectToAction("Services");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var shippingData = new ShippingWithServiceListVM
            {
                Shipping = await _services.ShippingService.GetSingleShippingType((int)id),
                ShippingServices = await _services.ShippingService.GetIndividualsServices((int)id)
            };

            return View(shippingData);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ShippingWithServiceListVM model, int[] SelectedServices)
        {
            if (ModelState.IsValid)
            {
                var shippingData = new Shipping()
                {
                    Id = model.Shipping.Id,
                    Type = model.Shipping.Type,
                    Price = model.Shipping.Price,
                    Description = model.Shipping.Description
                };

                _services.ShippingService.UpdateShipping(shippingData);
                await _services.ShippingService.CreateOrUpdateServiceForShipping(model.Shipping.Id, SelectedServices);

                TempData["success"] = "Service Updated Successfully!";
                return RedirectToAction("Index");
            }

            model.ShippingServices = await _services.ShippingService.GetIndividualsServices(model.Shipping.Id);
            return View(model);
        }
        #endregion
    }
}
