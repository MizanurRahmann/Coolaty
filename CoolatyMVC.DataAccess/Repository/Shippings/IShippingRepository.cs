using CoolatyMVC.Models;
using CoolatyMVC.Models.ViewModels;

namespace CoolatyMVC.Data.Repository.Shippings
{
    public interface IShippingRepository
    {
        Task<IEnumerable<ShippingWithServiceListVM>> GetAllShippingTypes();
        Task<IEnumerable<ShippingService>> GetAllShippingServices();
        Task<IEnumerable<ShippingServiceVM>> GetIndividualsServices(int shippingId);
        Task<Shipping> GetSingleShippingType(int shippingId);
        Task<ShippingService> GetSingleShippingService(int serviceId);
        Task CreateShippingService(ShippingService model);
        Task CreateOrUpdateServiceForShipping(int shippingId, int[] serviceList);
        void UpdateShipping(Shipping model);
        void UpdateShippingService(ShippingService model);
        void DeleteShippingService(ShippingService model);
    }
}
