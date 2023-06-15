using CoolatyMVC.Data.Repository.OrderDetails;
using CoolatyMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CoolatyMVC.Data.Repository.Orders
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        #region Fields
        private readonly ApplicationDbContext _db;
        #endregion

        #region Construstor
        public OrderDetailsRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<OrderDetail>> GetAllOrders()
        {
            var result = _db.OrderDetails.AsQueryable();
            return await Task.FromResult(result);
        }

        public async Task<OrderDetail> GetOrderDetail(int orderId)
        {
            return await _db.OrderDetails.FirstOrDefaultAsync(c => c.Id == orderId);
        }

        public void Create(OrderDetail model)
        {
            _db.OrderDetails.Add(model);
        }

        public void Update(OrderDetail model)
        {
            _db.OrderDetails.Update(model);
        }

        public void Delete(OrderDetail model)
        {
            _db.OrderDetails.Remove(model);
        }
        #endregion
    }
}
