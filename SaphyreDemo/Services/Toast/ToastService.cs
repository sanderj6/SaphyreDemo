using SaphyreDemo.Data.Models;
using System.Collections.ObjectModel;

namespace SaphyreDemo.Services.Toast
{
    public class ToastService
    {
        public ObservableCollection<ToastMessage> Toasts = new();

        public void Add(ToastMessage model)
        {
            Toasts.Add(model);
        }

        public void Remove(ToastMessage model)
        {
            if (Toasts.Contains(model))
                Toasts.Remove(model);
        }

        public void ShowMessage(string message)
        {
            ToastMessage newToast = new()
            {
                Title = "Info",
                Message = message,
                Type = ToastType.Info
            };

            Toasts.Add(newToast);
        }


        public void ShowError(string errorMessage)
        {
            ToastMessage newToast = new()
            {
                Title = "Error",
                Message = errorMessage,
                Type = ToastType.Error
            };

            Toasts.Add(newToast);
        }

        public void ClearAll()
        {
            if (!Toasts.Any()) return;
            foreach (var toast in Toasts.ToList())
            {
                Toasts.Remove(toast);
            }
        }
    }
}
