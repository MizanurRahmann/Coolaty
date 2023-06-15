
using CoolatyMVC.Data.Repository;
using CoolatyMVC.Models;

namespace CoolatyMVC.Services.Orders
{
    public class OrderService : IOrderService
    {
        #region Fields
        private readonly Repository _repo;
        #endregion

        #region Constructor
        public OrderService(Repository repo)
        {
            _repo = repo;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Order>> GetAllOrders(int pageNumber, int pageSize, string search)
        {
            return await _repo.Order.GetAllOrders(pageNumber, pageSize, search);
        }

        public async Task<Order> GetSingleOrder(int id)
        {
            return await _repo.Order.GetSingleOrder(id);
        }

        public async Task Create(Order model)
        {
            await _repo.Order.Create(model);
            _repo.Save();
        }

        public void Update(Order model)
        {
            _repo.Order.Update(model);
            _repo.Save();
        }

        public void Delete(Order model)
        {
            _repo.Order.Delete(model);
            _repo.Save();
        }

        public async Task UpdateStatus(int orderId, string orderStatus, string? paymentStatus = null)
        {
            await _repo.Order.UpdateStatus(orderId, orderStatus, paymentStatus);
            _repo.Save();
        }
        #endregion
    }
}
