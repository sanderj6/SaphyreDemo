using SaphyreDemo.Data.Models;

namespace SaphyreDemo.Services.Order
{
    public interface IOrderService
    {
        Task<OrderDescription> CreateOrderAsync(OrderDescription order);
        Task<OrderDescription> GetOrderByIdAsync(int orderId);
        Task<OrderDescription> UpdateOrderAsync(OrderDescription order);
        Task<bool> DeleteOrderAsync(int orderId);
        Task<IEnumerable<OrderDescription>> ListAllOrdersAsync();
    }

}
