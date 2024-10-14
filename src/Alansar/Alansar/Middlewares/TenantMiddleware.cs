using Alansar.Core.Entities;
using Alansar.Services;
using System.Data;

namespace Alansar.Middlewares
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantMiddleware(RequestDelegate next, IHttpContextAccessor httpContextAccessor)
        {
            _next = next;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            var o = _httpContextAccessor.HttpContext.Request.Headers["TenantId"].ToString();
            var d = _httpContextAccessor.HttpContext.Request.Headers["Role"].ToString();
            Console.WriteLine($"Headers - TenantId: {o}, Role: {d}");


            // Call the next middleware in the pipeline
            await _next(context);
        }
    }

}
