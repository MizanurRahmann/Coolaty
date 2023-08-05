using CoolatyMVC.Models;

namespace CoolatyMVC.Data.Repository.Shipping
{
    public interface IShippingRepository
    {
        Task<IEnumerable<ShippingService>> GetAllShippingServices();
        Task<ShippingService> GetSingleShippingService(int serviceId);
        Task CreateShippingService(ShippingService model);
        void UpdateShippingService(ShippingService model);
        void DeleteShippingService(ShippingService model);
    }
}
