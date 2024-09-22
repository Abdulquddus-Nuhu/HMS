using Alansar.Core.Entities;
using Alansar.Core.Entities.Identity;
using Alansar.Core.Enums;
using Alansar.Core.Models.Requests;
using Alansar.Core.Models.Responses;
using Alansar.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Alansar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;

        public TenantController(AppDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost("create-tenant")]
        public async Task<ActionResult> CreateTenant([FromBody] CreateTenantRequest request)
        {
            var apiResponse = new BaseResponse();

            var tenant = new Tenant()
            {
                SchoolName = request.SchoolName,
                Email = request.Email,
            };
            await _context.Tenants.AddAsync(tenant);
            //await _context.SaveChangesAsync();


            var user = new User
            {
                FirstName = "Admin",
                LastName = string.Empty,
                UserName = request.Email,
                Email = request.Email,
                RoleType = RoleType.TenantAdmin,
                TenantKey = $"{tenant.Id}",
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, nameof(RoleType.TenantAdmin));
            }
            else
            {
                apiResponse.Status = false;
                apiResponse.Message = result.Errors.FirstOrDefault().Description;
                return BadRequest(apiResponse);
            }


            var tenantSubscription = new TenantSubscription()
            {
                TenantId = tenant.Id,
                TenantKey = tenant.Id.ToString(),  //required for filteration by tenant
                PlanType = request.PlanType,
                BillingCycle = request.BillingCycle,
                HasPaid = false,
            };

            if (request.PlanType == SubscriptionPlanType.Free)
            {
                tenantSubscription.StartDate = DateTime.UtcNow;
                //todo: change later
                tenantSubscription.EndDate = DateTime.UtcNow.AddMinutes(5);
            }

            _context.TenantSubscriptions.Add(tenantSubscription);

            await _context.SaveChangesAsync();
            return Ok(new BaseResponse());
        }
    }
}
