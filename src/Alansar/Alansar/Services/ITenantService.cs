using Alansar.Core.Enums;

namespace Alansar.Services
{
    public interface ITenantService
    {
        string? GetCurrentUserRole();
        string? GetCurrentUserTenantId();
        bool IsAdminOrSuperAdmin();
    }
}
