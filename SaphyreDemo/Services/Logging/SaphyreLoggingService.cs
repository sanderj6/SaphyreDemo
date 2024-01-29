using SaphyreDemo.Services.Toast;

namespace SaphyreDemo.Services.Logging
{
    public class SaphyreLoggingService
    {
        private readonly ILogger<SaphyreLoggingService> _logger;
        private readonly ToastService _toastService;

        public SaphyreLoggingService(ILogger<SaphyreLoggingService> logger, ToastService toastService)
        {
            _logger = logger;
            _toastService = toastService;
        }

        public void LogError(string message)
        {
            _logger.LogError(message);
            _toastService.ShowError(message);
        }

    }
}
