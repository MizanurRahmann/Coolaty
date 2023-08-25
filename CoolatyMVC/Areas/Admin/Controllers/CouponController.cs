using CoolatyMVC.Models;
using CoolatyMVC.Models.ViewModels;
using CoolatyMVC.Services.Service;
using Microsoft.AspNetCore.Mvc;

namespace CoolatyMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CouponController : Controller
    {
        #region Filelds
        private readonly IService _services;
        private readonly ILogger<CategoriesController> _logger;
        private readonly IHttpContextAccessor _session;
        #endregion

        #region Constructor
        public CouponController(
            IService services,
            ILogger<CategoriesController> logger,
            IHttpContextAccessor sessionContext)
        {
            _logger = logger;
            _services = services;
            _session = sessionContext;
        }
        #endregion

        public async Task<IActionResult> Index([FromQuery(Name = "search")] string search)
        {
            var coupon = await _services.CouponService.GetAllCoupons(1, 100, search);
            return View(coupon);
        }

        [HttpGet]
        public async Task<IActionResult> Upsert(int? id)
        {
            CouponVM coupon = new()
            {
                Coupon = new(),
                ForNewUserText = "No"
            };

            if (id == null || id == 0)
            {
                return View(coupon);
            }

            coupon.Coupon = await _services.CouponService.GetSingleCoupon((int)id);
            coupon.ForNewUserText = coupon.Coupon.ForNewUser == true ? "Yes" : "No";
            
            return View(coupon);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(CouponVM model)
        {
            if (ModelState.IsValid)
            {
                var domainModel = new Coupon()
                {
                    Id = model.Coupon.Id,
                    Name = model.Coupon.Name,
                    Code = model.Coupon.Code,
                    Type = model.Coupon.Type,
                    DiscountAmount = model.Coupon.DiscountAmount,
                    ExpireDate = model.Coupon.Status == "Expired" ? DateTime.Now : model.Coupon.ExpireDate,
                    MinimumCost = model.Coupon.MinimumCost,
                    MinimumItem = model.Coupon.MinimumItem,
                    ForNewUser = model.ForNewUserText == "Yes" ? true : false,
                    Status = model.Coupon.Status,
                };

                if(model.Coupon.ExpireDate < DateTime.Now)
                {
                    domainModel.Status = "Expired";
                }
                else if(model.Coupon.Status == "Expired")
                {
                    domainModel.Status = "Active";
                }

                if (model.Coupon.Id == 0)
                {
                    domainModel.CreatedAt = DateTime.Now;
                    domainModel.ModifiedAt = DateTime.Now;
                    await _services.CouponService.Create(domainModel);
                    TempData["success"] = "Created Successfully!";
                }
                else
                {
                    domainModel.ModifiedAt = DateTime.Now;
                    _services.CouponService.Update(domainModel);
                    TempData["success"] = "Updated Successfully!";
                }

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Coupon data = await _services.CouponService.GetSingleCoupon(id);

            if (data != null)
            {
                _services.CouponService.Delete(data);
                TempData["success"] = "Deleted Successfully!";
                return RedirectToAction("Index");
            }

            TempData["error"] = "Something went wrong!";
            return RedirectToAction("Index");
        }
    }
}
