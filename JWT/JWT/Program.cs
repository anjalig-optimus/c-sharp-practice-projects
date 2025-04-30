using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

 void ConfigureServices(IServiceCollection services)
{
    SetupJWTServices(services);
    services.AddControllers();
}
 void SetupJWTServices(IServiceCollection services)
{
    string key = "my_secret_key_12345"; //this should be same which is used while creating token      
    var issuer = "http://mysite.com";  //this should be same which is used while creating token  

    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(options =>
  {
      options.TokenValidationParameters = new TokenValidationParameters
      {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateIssuerSigningKey = true,
          ValidIssuer = issuer,
          ValidAudience = issuer,
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
      };

      options.Events = new JwtBearerEvents
      {
          OnAuthenticationFailed = context =>
          {
              if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
              {
                  context.Response.Headers.Add("Token-Expired", "true");
              }
              return Task.CompletedTask;
          }
      };
  });
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
