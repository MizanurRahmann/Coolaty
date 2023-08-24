using CoolatyMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolatyMVC.Data.Repository.Coupons
{
    public class CouponRepository : ICouponRepository
    {
        #region Fields
        private readonly ApplicationDbContext _db;
        #endregion

        #region Construstor
        public CouponRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Coupon>> GetAllCoupons(int pageNumber, int pageSize, string search)
        {
            var result = _db.Coupons.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(coupon => coupon.Name.Contains(search));
            }

            result = result.OrderBy(p => p.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            return await Task.FromResult(result);
        }

        public async Task<Coupon> GetSingleCoupon(int categoryId)
        {
            return await _db.Coupons.FirstOrDefaultAsync(c => c.Id == categoryId);
        }

        public async Task Create(Coupon model)
        {
            await _db.Coupons.AddAsync(model);
        }

        public void Update(Coupon model)
        {
            _db.Coupons.Update(model);
        }

        public void Delete(Coupon model)
        {
            _db.Coupons.Remove(model);
        }
        #endregion
    }
}
