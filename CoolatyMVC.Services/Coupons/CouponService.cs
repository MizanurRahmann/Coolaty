using CoolatyMVC.Data.Repository;
using CoolatyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolatyMVC.Services.Coupons
{
    public class CouponService : ICouponService
    {
        #region Fields
        private readonly Repository _repo;
        #endregion

        #region Constructor
        public CouponService(Repository repo)
        {
            _repo = repo;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Coupon>> GetAllCoupons(int pageNumber, int pageSize, string search)
        {
            return await _repo.Coupon.GetAllCoupons(pageNumber, pageSize, search);
        }

        public async Task<Coupon> GetSingleCoupon(int id)
        {
            return await _repo.Coupon.GetSingleCoupon(id);
        }

        public async Task Create(Coupon model)
        {
            await _repo.Coupon.Create(model);
            _repo.Save();
        }

        public void Update(Coupon model)
        {
            _repo.Coupon.Update(model);
            _repo.Save();
        }

        public void Delete(Coupon model)
        {
            _repo.Coupon.Delete(model);
            _repo.Save();
        }
        #endregion
    }
}
