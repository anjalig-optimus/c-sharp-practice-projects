using Core.Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Core.Application.Query;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var provider=builder.Services.BuildServiceProvider();
var config=provider.GetService<IConfiguration>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IStudent, Student>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllStudentsQuery).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
