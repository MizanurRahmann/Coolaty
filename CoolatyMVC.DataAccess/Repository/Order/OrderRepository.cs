using CoolatyMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CoolatyMVC.Data.Repository.Orders
{
    public class OrderRepository : IOrderRepository
    {
        #region Fields
        private readonly ApplicationDbContext _db;
        #endregion

        #region Construstor
        public OrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Order>> GetAllOrders(int pageNumber, int pageSize, string search)
        {
            var result = _db.Orders.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(category => category.Name.Contains(search));
            }

            result = result.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<Order>> GetMyOrders(string userId)
        {
            var result = _db.Orders.Where(item => item.AppUserId == userId);
            return await Task.FromResult(result);
        }

        public async Task<Order> GetSingleOrder(int orderId)
        {
            return await _db.Orders.FirstOrDefaultAsync(c => c.Id == orderId);
        }

        public async Task Create(Order model)
        {
            await _db.Orders.AddAsync(model);
        }

        public void Update(Order model)
        {
            _db.Orders.Update(model);
        }

        public void Delete(Order model)
        {
            _db.Orders.Remove(model);
        }

        public async Task UpdateStatus(int orderId, string orderStatus, string? paymentStatus = null)
        {
            var order = await _db.Orders.FirstOrDefaultAsync(c => c.Id == orderId);

            if(order != null)
            {
                order.OrderStatus = orderStatus;
                if(paymentStatus != null)
                {
                    order.PaymentStatus = paymentStatus;
                }
            }
        }
        #endregion
    }
}
