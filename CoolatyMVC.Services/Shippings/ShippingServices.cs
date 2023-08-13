using CoolatyMVC.Data.Repository;
using CoolatyMVC.Models;
using CoolatyMVC.Models.ViewModels;

namespace CoolatyMVC.Services.Shippings
{
    public class ShippingServices : IShippingServices
    {
        #region Fields
        private readonly Repository _repo;
        #endregion

        #region Constructor
        public ShippingServices(Repository repo)
        {
            _repo = repo;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<ShippingWithServiceListVM>> GetAllShippingTypes()
        {
            return await _repo.Shipping.GetAllShippingTypes();

        }

        public async Task<IEnumerable<ShippingService>> GetAllShippingServices()
        {
            return await _repo.Shipping.GetAllShippingServices();

        }

        public async Task<IEnumerable<ShippingServiceVM>> GetIndividualsServices(int shippingId)
        {
            return await _repo.Shipping.GetIndividualsServices(shippingId);
        }

        public async Task<ShippingService> GetSingleShippingService(int serviceId)
        {
            return await _repo.Shipping.GetSingleShippingService(serviceId);
        }

        public async Task<Shipping> GetSingleShippingType(int shippingId)
        {
            return await _repo.Shipping.GetSingleShippingType(shippingId);
        }

        public async Task CreateShippingService(ShippingService model)
        {
            await _repo.Shipping.CreateShippingService(model);
            await _repo.SaveAsync();
        }

        public async Task CreateOrUpdateServiceForShipping(int shippingId, int[] serviceList)
        {
            await _repo.Shipping.CreateOrUpdateServiceForShipping(shippingId, serviceList);
            _repo.Save();
        }

        public void UpdateShipping(Shipping model)
        {
            _repo.Shipping.UpdateShipping(model);
            _repo.Save();
        }

        public void UpdateShippingService(ShippingService model)
        {
            _repo.Shipping.UpdateShippingService(model);
            _repo.Save();
        }

        public void DeleteShippingService(ShippingService model)
        {
            _repo.Shipping.DeleteShippingService(model);
            _repo.Save();
        }
        #endregion

    }
}
