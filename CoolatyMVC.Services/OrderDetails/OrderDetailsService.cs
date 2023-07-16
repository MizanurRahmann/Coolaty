
using CoolatyMVC.Data.Repository;
using CoolatyMVC.Models;

namespace CoolatyMVC.Services.OrderDetails
{
    public class OrderDetailsService : IOrderDetailsService
    {
        #region Fields
        private readonly Repository _repo;
        #endregion

        #region Constructor
        public OrderDetailsService(Repository repo)
        {
            _repo = repo;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<OrderDetail>> GetAllOrders()
        {
            return await _repo.OrderDetail.GetAllOrders();
        }

        public async Task<OrderDetail> GetOrderDetails(int id)
        {
            return await _repo.OrderDetail.GetOrderDetail(id);
        }

        public void Create(OrderDetail model)
        {
            _repo.OrderDetail.Create(model);
            _repo.Save();
        }

        public void Update(OrderDetail model)
        {
            _repo.OrderDetail.Update(model);
            _repo.Save();
        }

        public void Delete(OrderDetail model)
        {
            _repo.OrderDetail.Delete(model);
            _repo.Save();
        }
        #endregion
    }
}
