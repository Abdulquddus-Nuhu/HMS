using Alansar.Core.Entities;
using Alansar.Core.Entities.Identity;
using Alansar.Core.Enums;
using Alansar.Core.Models.Requests;
using Alansar.Core.Models.Responses;
using Alansar.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alansar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        //private readonly IdentityDbContext _identityDbContext;
        private readonly UserManager<User> _userManager;

        public TenantController(AppDbContext appDbContext,/* IdentityDbContext identityDbContext,*/ UserManager<User> userManager)
        {
            _appDbContext = appDbContext;
            //_identityDbContext = identityDbContext;
            _userManager = userManager;
        }

        // Assuming you have your DbContext as `IdentityDbContext`
        //private async Task AddRoleToUserManually(int userId, string roleName)
        //{
        //    // Get the user by ID
        //    var user = await _identityDbContext.Users.FindAsync(userId);
        //    if (user == null)
        //    {
        //        throw new Exception("User not found");
        //    }

        //    // Get the role by name
        //    var role = await _identityDbContext.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
        //    if (role == null)
        //    {
        //        throw new Exception("Role not found");
        //    }

        //    // Create a new IdentityUserRole object
        //    var userRole = new IdentityUserRole<int>
        //    {
        //        UserId = user.Id, // Set the user ID
        //        RoleId = role.Id  // Set the role ID
        //    };

        //    // Add the user-role relationship to the IdentityUserRoles table
        //    //_appDbContext.UserRoles.Add(userRole);
        //    //_identityDbContext.UserRoles.Add(userRole);

        //    // Save the changes to the database
        //    await _appDbContext.SaveChangesAsync();
        //    //await _identityDbContext.SaveChangesAsync();
        //}

        //Assuming you have your DbContext as `IdentityDbContext`
        private async Task AddRoleToUserManually(int userId, string roleName)
        {
            // Get the user by ID
            var user = await _appDbContext.Users.FindAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            // Get the role by name
            var role = await _appDbContext.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
            if (role == null)
            {
                throw new Exception("Role not found");
            }

            // Create a new IdentityUserRole object
            var userRole = new IdentityUserRole<int>
            {
                UserId = user.Id, // Set the user ID
                RoleId = role.Id  // Set the role ID
            };

            // Add the user-role relationship to the IdentityUserRoles table
            //_appDbContext.UserRoles.Add(userRole);
            //_identityDbContext.UserRoles.Add(userRole);

            // Save the changes to the database
            await _appDbContext.SaveChangesAsync();
            //await _identityDbContext.SaveChangesAsync();
        }


        [HttpPost("create-tenant")]
        public async Task<ActionResult> CreateTenant([FromBody] CreateTenantRequest request)
        {
            var apiResponse = new BaseResponse();

            var tenant = new Tenant()
            {
                Id = Guid.NewGuid(),
                SchoolName = request.SchoolName,
                Email = request.Email,
            };
            await _appDbContext.Tenants.AddAsync(tenant);
            //await _identityDbContext.Tenants.AddAsync(tenant);
            //await _context.SaveChangesAsync();


            var user = new User
            {
                Id = 50,
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
                //var createdUser = await _userManager.FindByEmailAsync(user.Email);

                //await AddRoleToUserManually(user.Id, nameof(RoleType.TenantAdmin));
                await AddRoleToUserManually(user.Id, nameof(RoleType.TenantAdmin));
                //await _userManager.AddToRoleAsync(createdUser, nameof(RoleType.TenantAdmin));
                //await _userManager.AddToRoleAsync(user, nameof(RoleType.TenantAdmin));
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

            _appDbContext.TenantSubscriptions.Add(tenantSubscription);
            //_identityDbContext.TenantSubscriptions.Add(tenantSubscription);

            await _appDbContext.SaveChangesAsync();
            //await _identityDbContext.SaveChangesAsync();
            return Ok(new BaseResponse());
        }
    }
}
