using CoolatyMVC.Services.Products;
using CoolatyMVC.Services.Categories;
using CoolatyMVC.Data.Repository;
using CoolatyMVC.Models;
using Microsoft.AspNetCore.Http;

namespace CoolatyMVC.Services.Service
{
    public class Service : IService
    {
        private readonly Repository _repo;
        public ICategoryService Category { get; private set; }
        public IProductService Products { get; private set; }

        public Service(Repository repo)
        {
            _repo = repo;
            Category = new CategoryService(_repo);
            Products = new ProductService(_repo);
        }

        public async Task<byte[]> GetBytes(IFormFile image)
        {
            await using var memoryStream = new MemoryStream();
            await image.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
