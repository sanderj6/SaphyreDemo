namespace SaphyreDemo.Data.Models
{
    public class ToastMessage
    {
        public Guid Id { get; set; }
        public ToastType Type { get; set; }
        public string ImageSource { get; set; }
        public string CustomIconName { get; set; }
        public string Title { get; set; } = "NOTE";
        public string HelpText { get; set; }
        public string Message { get; set; }
    }

    public enum ToastType
    {
        Info,
        Warning,
        Error,
        Success
    }

}
