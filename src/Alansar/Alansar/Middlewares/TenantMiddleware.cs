using Alansar.Core.Entities;
using Alansar.Services;
using System.Data;

namespace Alansar.Middlewares
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ITenantService _tenantService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantMiddleware(RequestDelegate next, ITenantService tenantService, IHttpContextAccessor httpContextAccessor)
        {
            _next = next;
            _tenantService = tenantService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            var o = _httpContextAccessor.HttpContext.Request.Headers["TenantId"].ToString();
            var d = _httpContextAccessor.HttpContext.Request.Headers["Role"].ToString();
            Console.WriteLine($"Headers - TenantId: {o}, Role: {d}");


            var userRole = _tenantService.GetCurrentUserRole();
            var userTenantId = _tenantService.GetCurrentUserTenantId();
            Console.WriteLine($"Tenant service-Headers - TenantId: {userTenantId}, Role: {userRole}");


            context.Items["UserRole"] = userRole;
            context.Items["TenantId"] = userTenantId;

            // Call the next middleware in the pipeline
            await _next(context);
        }
    }

}
