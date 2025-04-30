using EmployeeAdminPortal.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//INJECTING DBCONTEXT FILE
builder.Services.AddDbContext<ApplicationDbContext>(
options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
IConfiguration configuration = builder.Configuration;
var testvalue = configuration["test:key"];


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.Use(async(context, next)=>{
//    await context.Response.WriteAsync("Hello");
//    await next(context);
//});

app.UseHttpsRedirection();

app.UseAuthorization();

//CONVENTION BASED ROUTING
app.MapControllers(
    //name: "default",
    //pattern:"{controller=Home}/{action=index}/{id}"          id is optional
    );

// ATTRIBUTE BASED
//[Route("Home/About")]
//public IActionResult About()
//{
//    return View;
//}

app.Run();
