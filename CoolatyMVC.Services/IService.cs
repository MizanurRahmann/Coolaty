using CoolatyMVC.Services.Products;
using CoolatyMVC.Services.Category;
using Microsoft.AspNetCore.Http;

namespace CoolatyMVC.Services.Service
{
    public interface IService
    {
        IProductService Products { get; }
        ICategoryService Category { get; }
        Task<byte[]> GetBytes(IFormFile image);
    }
}
