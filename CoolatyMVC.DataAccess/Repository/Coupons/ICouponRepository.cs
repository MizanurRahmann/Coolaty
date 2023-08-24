using CoolatyMVC.Models;

namespace CoolatyMVC.Data.Repository.Coupons
{
    public interface ICouponRepository
    {
        Task<IEnumerable<Coupon>> GetAllCoupons(int pageNumber, int pageSize, string search);
        Task<Coupon> GetSingleCoupon(int categoryId);
        Task Create(Coupon model);
        void Update(Coupon model);
        void Delete(Coupon model);
    }
}
