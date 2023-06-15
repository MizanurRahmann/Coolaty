using CoolatyMVC.Models;

namespace CoolatyMVC.Services.OrderDetails
{
    public interface IOrderDetailsService
    {
        Task<IEnumerable<OrderDetail>> GetAllOrders();
        Task<OrderDetail> GetOrderDetails(int orderId);
        void Create(OrderDetail model);
        void Update(OrderDetail model);
        void Delete(OrderDetail model);
    }
}
