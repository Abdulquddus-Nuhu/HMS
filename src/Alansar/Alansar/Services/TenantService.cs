using Alansar.Core.Enums;
using System.Security.Claims;

namespace Alansar.Services
{
    public class TenantService : ITenantService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? GetCurrentUserRole()
        {
            return  _httpContextAccessor.HttpContext.User.FindFirst("role")?.Value;
        }

        public string? GetCurrentUserTenantId()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst("tenantId")?.Value;
        }

        public bool IsAdminOrSuperAdmin()
        {
            var role = GetCurrentUserRole();
            return role == RoleType.Admin.ToString() || role == RoleType.SuperAdmin.ToString();
        }
    }
}
