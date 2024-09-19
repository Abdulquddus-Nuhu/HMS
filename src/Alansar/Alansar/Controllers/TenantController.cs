using Alansar.Core.Entities;
using Alansar.Core.Entities.Identity;
using Alansar.Core.Models.Requests;
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

        [HttpPost]
        public async Task<ActionResult> CreateTenant([FromBody] CreateTenantRequest request)
        {
            var tenant = new Tenant()
            {
                SchoolName = request.SchoolName,
                Email = request.Email,
            };

            var tenantSubscription = new TenantSubscription()
            {
                TenantId = tenant.Id,
                PlanType = request.PlanType,
                BillingCycle = request.BillingCycle,
                HasPaid = false,
            };

            if (request.PlanType == Core.Enums.SubscriptionPlanType.Free)
            {
                tenantSubscription.StartDate = DateTime.UtcNow;
                //todo: change later
                tenantSubscription.EndDate = DateTime.UtcNow.AddMinutes(5);
            }

            //_context.Students.Add(newStudent);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
