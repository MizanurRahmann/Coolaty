using CoolatyMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CoolatyMVC.Data.Repository.Shipping
{
    public class ShippingRepository : IShippingRepository
    {
        #region Fields
        private readonly ApplicationDbContext _db;
        #endregion

        #region Construstor
        public ShippingRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<ShippingService>> GetAllShippingServices()
        {
            var result = _db.ShippingServices.AsQueryable();
            return await Task.FromResult(result);
        }
        public async Task<ShippingService> GetSingleShippingService(int serviceId)
        {
            return await _db.ShippingServices.FirstOrDefaultAsync(c => c.Id == serviceId);
        }

        public async Task CreateShippingService(ShippingService model)
        {
            await _db.ShippingServices.AddAsync(model);
        }

        public void UpdateShippingService(ShippingService model)
        {
            _db.ShippingServices.Update(model);
        }

        public void DeleteShippingService(ShippingService model)
        {
            _db.ShippingServices.Remove(model);
        }
        #endregion

    }
}
