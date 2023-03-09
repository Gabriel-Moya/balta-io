using DependencyStore.Repositories;
using DependencyStore.Repositories.Contracts;
using DependencyStore.Services;
using DependencyStore.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();
builder.Services.AddTransient<IDeliveryFeeService, DeliveryFeeService>();

var app = builder.Build();

app.MapControllers();

app.Run();