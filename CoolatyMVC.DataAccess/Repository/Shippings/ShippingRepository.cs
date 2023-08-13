using CoolatyMVC.Models;
using CoolatyMVC.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CoolatyMVC.Data.Repository.Shippings
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
        public async Task<IEnumerable<ShippingWithServiceListVM>> GetAllShippingTypes()
        {
            var result = from s in _db.Shipping
                      select new ShippingWithServiceListVM
                      {
                          Shipping = new Shipping
                          {
                              Id = s.Id,
                              Type = s.Type,
                              Description = s.Description,
                              Price = s.Price,
                          },
                          ShippingServices = (from sj in _db.ShippingServiceJunctions
                                              join ss in _db.ShippingServices
                                              on sj.ServiceId equals ss.Id
                                              where sj.ShippingId == s.Id && sj.IsActive
                                              select new ShippingServiceVM
                                              {
                                                  Id = ss.Id,
                                                  Feature = ss.Feature,
                                                  IsServiceEnabled = sj.IsActive
                                              }).ToList()

                      };

            return await result.ToListAsync();
        }

        public async Task<IEnumerable<ShippingService>> GetAllShippingServices()
        {
            var result = _db.ShippingServices.AsQueryable();
            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<ShippingServiceVM>> GetIndividualsServices(int shippingId)
        {
            var result = from service in _db.ShippingServices
                        join junction in _db.ShippingServiceJunctions
                            on new { ServiceId = service.Id, ShippingId = shippingId } equals new { junction.ServiceId, junction.ShippingId }
                            into serviceJunction
                        from sj in serviceJunction.DefaultIfEmpty()
                        select new ShippingServiceVM
                        {
                            Id = service.Id,
                            Feature = service.Feature,
                            IsServiceEnabled = sj != null ? sj.IsActive : false
                        };
            
            return await result.ToListAsync();
        }

        public async Task<Shipping> GetSingleShippingType(int shippingId)
        {
            return await _db.Shipping.FirstOrDefaultAsync(s => s.Id == shippingId);
        }

        public async Task<ShippingService> GetSingleShippingService(int serviceId)
        {
            return await _db.ShippingServices.FirstOrDefaultAsync(c => c.Id == serviceId);
        }

        public async Task CreateShippingService(ShippingService model)
        {
            await _db.ShippingServices.AddAsync(model);
        }

        public async Task CreateOrUpdateServiceForShipping(int shippingId, int[] serviceList)
        {
            // make isActive = false for all services for this shipping id
            var allServicesForThisShipping = await _db.ShippingServiceJunctions
                                                .Where(s => s.ShippingId == shippingId)
                                                .ToListAsync();
            
            foreach (var service in allServicesForThisShipping)
            {
                service.IsActive = false;
            }

            // make active services that are in the serviceList array
            foreach (int serviceId in serviceList)
            {
                var activeRecord = _db.ShippingServiceJunctions
                    .FirstOrDefault(j => j.ShippingId == shippingId && j.ServiceId == serviceId);
                
                if (activeRecord != null)
                {
                    activeRecord.IsActive = true;
                }
                else
                {
                    var newRecord = new ShippingServiceJunction
                    {
                        ShippingId = shippingId,
                        ServiceId = serviceId,
                        IsActive = true
                    };

                    _db.ShippingServiceJunctions.Add(newRecord);
                }
            }
        }

        public void UpdateShipping(Shipping model)
        {
            _db.Shipping.Update(model);
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
