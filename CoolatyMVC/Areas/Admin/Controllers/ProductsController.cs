using CoolatyMVC.Models;
using CoolatyMVC.Services.Service;
using Microsoft.AspNetCore.Http;
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
        // GET ALL PRODUCT
        [HttpGet]
        public async Task<IActionResult> Index(string search)
        {
            var productData = await _services.Products.GetAllProducts(1, 10, search, "Admin");
            return View(productData);
        }

        // GET ADD NEW PRODUCT PAGE
        [HttpGet]
        public IActionResult Create()
        {
            return View("~/Areas/Admin/Views/Products/Create.cshtml");
        }

        // POST NEW PRODUCT
        [HttpPost]
        public async Task<IActionResult> Create(ProductModel model)
        {
            // convert image file to base64 string
            string hexString = "";
            if (model.Image != null)
            {
                var bytes = await GetBytes(model);
                hexString = Convert.ToBase64String(bytes);
                model.ImageUrl = hexString;
            }

            // clear previous validation & rerun validation function
            ModelState.Clear();
            TryValidateModel(model);

            // check model validty
            if (ModelState.IsValid)
            {
                var domainModel = new ProductModel()
                {
                    Id = model.Id,
                    Name = model.Name,
                    ImageUrl = model.ImageUrl,
                    Price = model.Price,
                    SubName = model.SubName,
                    Compound = model.Compound,
                    Calories = model.Calories,
                    Carbohydrates = model.Carbohydrates,
                    Proteins = model.Proteins,
                    Fats = model.Fats,
                    CategoryId = model.CategoryId,
                };

                await _services.Products.Create(domainModel);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var viewData = await _services.Products.GetSingleProduct(id);
            
            if(viewData == null)
            {
                return View("~/Areas/Admin/Views/Products/_NotFound.cshtml");
            }

            return View("~/Areas/Admin/Views/Products/Edit.cshtml", viewData);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Private Methods
        private async Task<byte[]> GetBytes(ProductModel model)
        {
            await using var memoryStream = new MemoryStream();
            await model.Image.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
        #endregion
    }
}
