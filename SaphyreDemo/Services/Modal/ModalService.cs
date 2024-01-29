using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using SaphyreDemo.Data.Models;
using SaphyreDemo.Templates.Modal.SaphyreDemo.Templates.Modals;

namespace SaphyreDemo.Services.Modal
{
    public class ModalService
    {

        // Actions for Show/Close Events
        public event Action<string, RenderFragment, string> OnShow;
        public event Action OnClose;
 
        // Show Methods
        /// <summary>
        /// Launches a Modal with a <paramref name="contentType"/> and <paramref name="callback"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="title">Title to display.</param>
        /// <param name="classSize">Size of Modal to render.</param>
        /// <param name="contentType">Component Class.</param>
        /// <param name="callback">Action to trigger on close.</param>
        public void Show<T>(string title, string classSize, Type contentType, Action<T> callback)
        {
            try
            {
                if (contentType == null || !typeof(ComponentBase).IsAssignableFrom(contentType))
                {
                    throw new ArgumentException("Content type must be a Blazor component.");
                }

                var content = new RenderFragment(x =>
                {
                    x.OpenComponent(0, contentType);
                    x.AddAttribute(1, "Callback", callback);
                    x.CloseComponent();
                });

                OnShow?.Invoke(title, content, classSize);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        /// <summary>
        /// Shows a Modal including a <paramref name="model"/> and a <paramref name="callback"/>.
        /// </summary>
        /// <typeparam name="T">Generic Type for Model and Callback.</typeparam>
        /// <param name="title">Title of the Modal.</param>
        /// <param name="classSize">Modal size.</param>
        /// <param name="contentType">Type of Modal to launch.</param>
        /// <param name="model">Model to pass to the modal.</param>
        /// <param name="callback">Action using <paramref name="model"/> in the response.</param>
        public void Show<T, U>(string title, string classSize, Type contentType, T model, Action<U> callback)
        {
            try
            {
                if (contentType == null || !typeof(ComponentBase).IsAssignableFrom(contentType))
                {
                    throw new ArgumentException("Content type must be a Blazor component.");
                }

                var content = new RenderFragment(x =>
                {
                    x.OpenComponent(0, contentType);
                    x.AddAttribute(1, "Model", model);
                    x.AddAttribute(2, "Callback", callback);
                    x.CloseComponent();
                });

                OnShow?.Invoke(title, content, classSize);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// Shows a Modal including a <paramref name="model"/> and a <paramref name="callback"/>.
        /// </summary>
        /// <typeparam name="T">Generic Type for Model and Callback.</typeparam>
        /// <param name="title">Title of the Modal.</param>
        /// <param name="classSize">Modal size.</param>
        /// <param name="contentType">Type of Modal to launch.</param>
        /// <param name="model">Model to pass to the modal.</param>
        /// <param name="operation">CRUD Operation of performed action.</param>
        /// <param name="callback">Action using <paramref name="model"/> in the response.</param>
        public void Show<T, U>(string title, string classSize, Type contentType, T model, ModalOperation operation, Action<U> callback)
        {
            try
            {
                if (contentType == null || !typeof(ComponentBase).IsAssignableFrom(contentType))
                {
                    throw new ArgumentException("Content type must be a Blazor component.");
                }

                var content = new RenderFragment(x =>
                {
                    x.OpenComponent(0, contentType);
                    x.AddAttribute(1, "Model", model);
                    x.AddAttribute(2, "Callback", callback);
                    x.AddAttribute(3, "CRUDOperation", operation);
                    x.CloseComponent();
                });

                OnShow?.Invoke(title, content, classSize);
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public Task<U> ShowAsync<T, U>(string title, string classSize, Type contentType, T model)
        {
            var tcs = new TaskCompletionSource<U>();

            try
            {
                if (contentType == null || !typeof(ComponentBase).IsAssignableFrom(contentType))
                {
                    throw new ArgumentException("Content type must be a Blazor component.");
                }

                var content = new RenderFragment(x =>
                {
                    x.OpenComponent(0, contentType);
                    x.AddAttribute(1, "Model", model);
                    x.AddAttribute(2, "Callback", new Action<U>(result =>
                    {
                        tcs.SetResult(result); // Set the result of the TaskCompletionSource
                    }));
                    x.CloseComponent();
                });

                OnShow?.Invoke(title, content, classSize);
            }
            catch (Exception e)
            {
                tcs.SetException(e); // Set the exception if any occurs
            }

            return tcs.Task; // Return the task to await the result
        }

        // Close Method
        public void Close()
        {
            OnClose?.Invoke();
        }
    }
}
