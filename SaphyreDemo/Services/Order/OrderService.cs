using SaphyreDemo.Data.Models;

namespace SaphyreDemo.Services.Order
{
    public class OrderService : IOrderService
    {
        private ILogger<OrderService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private string baseUrl;

        public OrderService(ILogger<OrderService> logger, IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _httpClientFactory = clientFactory;

            baseUrl = configuration.GetValue<string>("OrderAPIURL") ?? string.Empty;
        }

        public async Task<OrderDescription> CreateOrderAsync(OrderDescription order)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.PostAsJsonAsync($"{baseUrl}/orders", order);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<OrderDescription>();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting order: {ex.Message}");
                return new OrderDescription();
            }
        }

        public async Task<OrderDescription> GetOrderByIdAsync(int orderId)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                return await client.GetFromJsonAsync<OrderDescription>($"{baseUrl}/orders/{orderId}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting order: {ex.Message}");
                return new OrderDescription();
            }
        }

        public async Task<IEnumerable<OrderDescription>> ListAllOrdersAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                return await client.GetFromJsonAsync<IEnumerable<OrderDescription>>($"{baseUrl}/orders");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting order: {ex.Message}");
                return new List<OrderDescription>();
            }
        }

        public async Task<OrderDescription> UpdateOrderAsync(OrderDescription order)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.PutAsJsonAsync($"{baseUrl}/orders/{order.Id}", order);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<OrderDescription>();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting order: {ex.Message}");
                return new OrderDescription();
            }
        }

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.DeleteAsync($"{baseUrl}/orders/{orderId}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting order: {ex.Message}");
                return false;
            }
        }
    }

}
