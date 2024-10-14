//using Alansar.Core.Entities;
//using Alansar.Services;
//using Microsoft.EntityFrameworkCore.Diagnostics;
//using Microsoft.EntityFrameworkCore;
//using System.Security.Claims;

//namespace Alansar.Data
//{
//    public class TenantSaveChangesInterceptor : SaveChangesInterceptor
//    {
//        private readonly IHttpContextAccessor _httpContextAccessor;
//        private readonly ITenantService _tenantService;

//        public TenantSaveChangesInterceptor(IHttpContextAccessor httpContextAccessor, ITenantService tenantService)
//        {
//            _httpContextAccessor = httpContextAccessor;
//            _tenantService = tenantService;
//        }

//        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
//        {

//            var httpContext = _httpContextAccessor.HttpContext;

//            // Check if HttpContext or User is null
//            if (httpContext is null || httpContext.User is null)
//            {
//                // Optionally log or handle the case where HttpContext is not available
//                return base.SavingChanges(eventData, result);
//            }

//            //if (_httpContextAccessor.HttpContext is null)
//            //{
//            //    return base.SavingChanges(eventData, result);
//            //}


//            var context = eventData.Context;
//            if (context != null)
//            {
//                var user = _httpContextAccessor.HttpContext.User;

//                var role = user.FindFirst(ClaimTypes.Role)?.Value;
//                var tenantKey = _tenantService.GetCurrentUserTenantId();

//                // Check each entity being added or modified
//                foreach (var entry in context.ChangeTracker.Entries())
//                {
//                    if (entry.Entity is ITenant tenantEntity && entry.State == EntityState.Added)
//                    {
//                        if (role == "Admin" || role == "SuperAdmin")
//                        {
//                            // For Admin or SuperAdmin, set TenantKey to whitespace
//                            tenantEntity.TenantKey = string.Empty;
//                        }
//                        else
//                        {
//                            if (tenantKey is null)
//                            {
//                                tenantEntity.TenantKey = "default";
//                            }
//                            else
//                            {
//                                tenantEntity.TenantKey = tenantKey;
//                            }
//                            // For other roles, set the TenantKey to the user's tenant key
//                            //tenantEntity.TenantKey = tenantKey;
//                        }
//                    }

//                    if (entry.Entity is ITenant tenantEntityModified && entry.State == EntityState.Modified)
//                    {
//                        if (role == "Admin" || role == "SuperAdmin")
//                        {
//                            // Ensure that Admin and SuperAdmin don't modify the tenant key
//                            tenantEntityModified.TenantKey = string.Empty;
//                        }
//                        else
//                        {
//                            // For other roles, keep TenantKey intact or update based on logic
//                            tenantEntityModified.TenantKey = tenantKey;
//                        }
//                    }
//                }
//            }

//            return base.SavingChanges(eventData, result);
//        }
//    }

//}
