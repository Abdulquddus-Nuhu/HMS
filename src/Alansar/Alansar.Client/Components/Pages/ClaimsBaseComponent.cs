using Microsoft.AspNetCore.Components;
using System.Security.Claims;

namespace Alansar.Client.Components.Pages
{
    public class ClaimsBaseComponent : ComponentBase
    {
        protected string TenantId = string.Empty;
        protected string Role = string.Empty;
        protected string Email = string.Empty;

        protected void ExtractUserClaims(ClaimsPrincipal claimsPrincipal)
        {
            TenantId = claimsPrincipal.FindFirst("tenantId")?.Value;
            Role = claimsPrincipal.FindFirst("role")?.Value;
            Email = claimsPrincipal.FindFirst(ClaimTypes.Email)?.Value;
        }
    }

}
