using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace pets.Midllewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RatingMidlleware
    {
        private readonly RequestDelegate _next;

        public RatingMidlleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RatingMidllewareExtensions
    {
        public static IApplicationBuilder UseRatingMidlleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMidlleware>();
        }
    }
}
