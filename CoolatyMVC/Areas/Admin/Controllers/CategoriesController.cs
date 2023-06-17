using CoolatyMVC.Models;
using CoolatyMVC.Services.Service;
using Microsoft.AspNetCore.Mvc;

namespace CoolatyMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        #region Filelds
        private readonly IService _services;
        private readonly ILogger<CategoriesController> _logger;
        private readonly IHttpContextAccessor _session;
        #endregion

        #region Constructor
        public CategoriesController(
            IService services,
            ILogger<CategoriesController> logger,
            IHttpContextAccessor sessionContext)
        {
            _logger = logger;
            _services = services;
            _session = sessionContext;
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery(Name = "search")] string search)
        {
            var categories = await _services.Category.GetAllCategories(1, 100, search);
            return View(categories);

        }

        [HttpGet]
        public async Task<IActionResult> Upsert(int? id)
        {
            var category = new Category();

            if (id == null || id == 0)
            {
                return View(category);
            }

            category = await _services.Category.GetSingleCategory((int)id);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Category model)
        {
            // convert image file to base64 string
            string hexString = "";
            if (model.Image != null)
            {
                var bytes = await _services.GetBytes(model.Image);
                hexString = Convert.ToBase64String(bytes);
                model.ImageUrl = hexString;
            }

            // clear previous validation & rerun validation function
            ModelState.Clear();
            TryValidateModel(model);

            // check model validty
            if (ModelState.IsValid)
            {
                var domainModel = new Category()
                {
                    Id = model.Id,
                    Name = model.Name,
                    ImageUrl = model.ImageUrl,
                };

                if (model.Id == 0)
                {
                    await _services.Category.Create(domainModel);
                    TempData["success"] = "Created Successfully!";
                }
                else
                {
                    _services.Category.Update(domainModel);
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
            Category data = await _services.Category.GetSingleCategory(id);

            if (data != null)
            {
                _services.Category.Delete(data);
                TempData["success"] = "Deleted Successfully!";
                return RedirectToAction("Index");
            }

            TempData["error"] = "Something went wrong!";
            return RedirectToAction("Index");
        }
        #endregion
    }
}
