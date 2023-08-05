using CoolatyMVC.Models;

namespace CoolatyMVC.Services.Shippings
{
    public interface IShippingServices
    {
        Task<IEnumerable<ShippingService>> GetAllShippingServices();
        Task<ShippingService> GetSingleShippingService(int serviceId);
        Task CreateShippingService(ShippingService model);
        void UpdateShippingService(ShippingService model);
        void DeleteShippingService(ShippingService model);
    }
}
