using CoolatyMVC.Models;

namespace CoolatyMVC.Data.Repository.OrderDetails
{
    public interface IOrderDetailsRepository
    {
        Task<IEnumerable<OrderDetail>> GetAllOrders();
        Task<OrderDetail> GetOrderDetail(int orderId);
        void Create(OrderDetail model);
        void Update(OrderDetail model);
        void Delete(OrderDetail model);
    }
}
