using CoolatyMVC.Models;

namespace CoolatyMVC.Services.Orders
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrders(int pageNumber, int pageSize, string search);
        Task<Order> GetSingleOrder(int orderId);
        Task Create(Order model);
        void Update(Order model);
        void Delete(Order model);
        Task UpdateStatus(int orderId, string orderStatus, string? paymentStatus = null);
    }
}
