using WebAPIUsecase.Application.Commands;
using WebAPIUsecase.Infrastructure.Data;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllers();
builder.Services.AddMediatR(typeof(CreateOrderCommandHandler).Assembly);

// Register repositories
builder.Services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();
builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.MapControllers();

app.Run();