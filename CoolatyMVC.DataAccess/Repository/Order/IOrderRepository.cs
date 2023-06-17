using CoolatyMVC.Models;

namespace CoolatyMVC.Data.Repository.Orders
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrders(int pageNumber, int pageSize, string search);
        Task<IEnumerable<Order>> GetMyOrders(string userId);
        Task<Order> GetSingleOrder(int orderId);
        Task Create(Order model);
        void Update(Order model);
        void Delete(Order model);
        Task UpdateStatus(int orderId, string orderStatus, string? paymentStatus = null);
    }
}
