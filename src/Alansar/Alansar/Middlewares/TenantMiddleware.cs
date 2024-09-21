using Alansar.Services;

namespace Alansar.Middlewares
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ITenantService _tenantService;

        public TenantMiddleware(RequestDelegate next, ITenantService tenantService)
        {
            _next = next;
            _tenantService = tenantService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var userRole = _tenantService.GetCurrentUserRole();
            var userTenantId = _tenantService.GetCurrentUserTenantId();

            context.Items["UserRole"] = userRole;
            context.Items["TenantId"] = userTenantId;

            // Call the next middleware in the pipeline
            await _next(context);
        }
    }

}
