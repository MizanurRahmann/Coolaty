using CoolatyMVC.Data.Repository;
using CoolatyMVC.Models;

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
        public async Task<IEnumerable<ShippingService>> GetAllShippingServices()
        {
            return await _repo.Shipping.GetAllShippingServices();

        }
        public async Task<ShippingService> GetSingleShippingService(int serviceId)
        {
            return await _repo.Shipping.GetSingleShippingService(serviceId);
        }

        public async Task CreateShippingService(ShippingService model)
        {
            await _repo.Shipping.CreateShippingService(model);
            await _repo.SaveAsync();
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
