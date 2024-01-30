using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Services;
using SaphyreDemo.Data;
using SaphyreDemo.Services.Logging;
using SaphyreDemo.Services.Modal;
using SaphyreDemo.Services.Order;
using SaphyreDemo.Services.Toast;
using FluentValidation;
using SaphyreDemo.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();

builder.Services.AddMudServices();
builder.Services.AddScoped<ModalService>();
builder.Services.AddScoped<IOrderService, OrderService>();

var toastService = new ToastService();
builder.Services.AddSingleton(toastService);
builder.Services.AddSingleton<DummyOrderService>();

builder.Services.AddValidatorsFromAssemblyContaining<OrderDescriptionValidator>();

//builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<YourModelValidator>());
//builder.Services.AddValidatorsFromAssemblyContaining<AnyValidator>() // register validators

//builder.Services.AddLogging(builder =>
//{
//    builder.AddProvider(new SaphyreLoggingService(toastService));
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
