using CoolatyMVC.Models;
using CoolatyMVC.Models.ViewModels;
using CoolatyMVC.Services.Service;
using Microsoft.AspNetCore.Mvc;

namespace CoolatyMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        #region Filelds
        private readonly IService _services;
        private readonly ILogger<ProductsController> _logger;
        private readonly IHttpContextAccessor _session;
        #endregion

        #region Constructor
        public ProductsController(
            IService services,
            ILogger<ProductsController> logger,
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
            var productData = await _services.Products.GetAllProducts(1, 100, search, "Admin");
            return View(productData);
        }

        [HttpGet]
        public async Task<IActionResult> Upsert(int? id)
        {
            ProductWithCategoryVM productWithCategory = new()
            {
                Product = new(),
                Category = (IEnumerable<Category>) await _services.Category.GetAllCategories(1, 100, "")
            };

            if (id == null || id == 0)
            {
                return View(productWithCategory);
            }
            else
            {
                productWithCategory.Product = await _services.Products.GetSingleProduct((int) id);
            }

            return View(productWithCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(ProductWithCategoryVM model)
        {
            // convert image file to base64 string
            string hexString = "";
            if (model.Product?.Image != null)
            {
                var bytes = await _services.GetBytes(model.Product.Image);
                hexString = Convert.ToBase64String(bytes);
                model.Product.ImageUrl = hexString;
            }

            // clear previous validation & rerun validation function
            ModelState.Clear();
            TryValidateModel(model);

            // check model validty
            if (ModelState.IsValid)
            {
                var domainModel = new Product()
                {
                    Id = model.Product.Id,
                    Name = model.Product.Name,
                    ImageUrl = model.Product.ImageUrl,
                    Price = model.Product.Price,
                    SubName = model.Product.SubName,
                    Compound = model.Product.Compound,
                    Calories = model.Product.Calories,
                    Carbohydrates = model.Product.Carbohydrates,
                    Proteins = model.Product.Proteins,
                    Fats = model.Product.Fats,
                    CategoryId = model.Product.CategoryId,
                };

                if (model.Product.Id == 0)
                {
                    await _services.Products.Create(domainModel);
                    TempData["success"] = "Created Successfully!";
                }
                else
                {
                    _services.Products.Update(domainModel);
                    TempData["success"] = "Updated Successfully!";
                }

                return RedirectToAction("Index");
            }

            if(model.Product.CategoryId == 0)
            {
                ModelState.AddModelError("Product.CategoryId", "Product Category is required.");
            }
            model.Category = await _services.Category.GetAllCategories(1, 100, "");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Product data = await _services.Products.GetSingleProduct(id);

            if (data != null)
            {
                _services.Products.Delete(data);
                TempData["success"] = "Deleted Successfully!";
                return RedirectToAction("Index");
            }

            TempData["error"] = "Something went wrong!";
            return RedirectToAction("Index");
        }
        #endregion
    }
}
