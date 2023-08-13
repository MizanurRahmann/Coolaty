using CoolatyMVC.Services.Products;
using CoolatyMVC.Services.Categories;
using CoolatyMVC.Services.ShopingCarts;
using CoolatyMVC.Data.Repository;
using Microsoft.AspNetCore.Http;
using CoolatyMVC.Services.AppUsers;
using CoolatyMVC.Services.Orders;
using CoolatyMVC.Services.OrderDetails;
using CoolatyMVC.Services.Shippings;

namespace CoolatyMVC.Services.Service
{
    public class Service : IService
    {
        private readonly Repository _repo;
        public ICategoryService Category { get; private set; }
        public IProductService Products { get; private set; }
        public IShopingCartService ShopingCart { get; private set; }
        public IOrderService Order { get; private set; }
        public IOrderDetailsService OrderDetails { get; private set; }
        public IAppUserService AppUser { get; private set; }
        public IShippingServices ShippingService { get; private set; }

        public Service(Repository repo)
        {
            _repo = repo;
            Category = new CategoryService(_repo);
            Products = new ProductService(_repo);
            ShopingCart = new ShopingCartService(_repo);
            Order = new OrderService(_repo);
            OrderDetails = new OrderDetailsService(_repo);
            AppUser = new AppUserService(_repo);
            ShippingService = new ShippingServices(_repo);
        }

        public async Task<byte[]> GetBytes(IFormFile image)
        {
            await using var memoryStream = new MemoryStream();
            await image.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
