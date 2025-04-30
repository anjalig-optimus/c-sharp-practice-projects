using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
namespace WebAppMiddleware.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
           { var buffer = new MemoryStream();
            var request = httpContext.Request;
            var response = httpContext.Response;

            var stream = response.Body;
            response.Body = buffer;
            await _next(httpContext);
            Debug.WriteLine($"Request content type:  {httpContext.Request.Headers["Accept"]} {System.Environment.NewLine} Request path: {request.Path} {System.Environment.NewLine} Response type: {response.ContentType} {System.Environment.NewLine} Response length: {response.ContentLength ?? buffer.Length}");
            buffer.Position = 0;

                await buffer.CopyToAsync(stream);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error occured ...go back");
            }
        }
    }
    // Extension method used to add the middleware to the HTTP request pipeline.
  
}