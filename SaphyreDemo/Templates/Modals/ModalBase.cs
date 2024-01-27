namespace SaphyreDemo.Templates.Modal
{
    using System;
    using global::SaphyreDemo.Services.Modal;
    using Microsoft.AspNetCore.Components;

    namespace SaphyreDemo.Templates.Modals
    {
        public class ModalBase : LayoutComponentBase, IDisposable
        {

            [Inject]
            protected ModalService ModalService { get; set; }
            protected bool IsVisible { get; set; }
            protected string Title { get; set; }
            protected string Class { get; set; }
            public string visibleClass => IsVisible ? "active" : "";
            protected RenderFragment Content { get; set; }

            protected override void OnInitialized()
            {
                ModalService.OnShow += ShowModal;
                ModalService.OnClose += CloseModal;
            }

            public void ShowModal(string title, RenderFragment content, string classSize)
            {
                Title = title;
                Content = content;
                Class = classSize;
                IsVisible = true;

                StateHasChanged();
            }

            public void CloseModal()
            {
                IsVisible = false;
                Title = "";
                Content = null;

                StateHasChanged();
            }

            public void Dispose()
            {
                ModalService.OnShow -= ShowModal;
                ModalService.OnClose -= CloseModal;
            }
        }
    }

}
