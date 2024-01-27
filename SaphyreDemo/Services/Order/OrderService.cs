using SaphyreDemo.Data.Models;

namespace SaphyreDemo.Services.Order
{
    public class OrderService : IOrderService
    {
        public Task<OrderDescription> CreateOrderAsync(OrderDescription order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOrderAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDescription> GetOrderByIdAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDescription>> ListAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDescription>> SearchOrdersAsync(string query)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDescription> UpdateOrderAsync(OrderDescription order)
        {
            throw new NotImplementedException();
        }
    }

}
