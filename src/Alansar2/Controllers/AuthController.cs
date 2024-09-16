using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Alansar.Enums;
using Alansar.Entities.Identity;
using Alansar.Data;
using Alansar.Entities;
using Microsoft.EntityFrameworkCore;
using Alansar.Models;

namespace Alansar.Controllers
{
    [AllowAnonymous]
    //[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    //[Route("api/")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _context;
        private readonly SignInManager<User> _signInManager;

        public AuthController(UserManager<User> userManager, AppDbContext context, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                //string emailExist = string.Concat(model.FirstName, model.LastName, "@", "alansar", ".com");
                //string userName = string.Concat(model.FirstName, model.LastName);

                //int sameEmailCount = await _context.Users.CountAsync(x => x.Email == emailExist);
                //if (sameEmailCount != 0)
                //{
                //    emailExist = string.Concat(model.FirstName, model.LastName, $"{sameEmailCount++}", "@", "alansar", ".com");
                //    userName = string.Concat(model.FirstName, model.LastName, $"{sameEmailCount++}");
                //}

                var user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MiddleName = model.MiddleName,
                    //UserName = userName,
                    //Email = emailExist,
                    UserName = model.Email,
                    Email = model.Email,
                    RoleType = RoleType.Student
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var student = new Student
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        MiddleName = model.MiddleName,
                        //Email = emailExist,
                        Email = model.Email,
                        UserId = user.Id,
                        DateOfBirth = DateTime.UtcNow,  // Store the Date of Birth
                        //DateOfBirth = model.DateOfBirth.Value,  // Store the Date of Birth
                    };
                    _context.Students.Add(student);
                    await _context.SaveChangesAsync();
                    await _userManager.AddToRoleAsync(user, "Student");
                    return Ok(new { message = "Success" });
                }
                var error = result.Errors.FirstOrDefault().Description;
                return BadRequest(new { message = result.Errors.FirstOrDefault().Description });
            }
            return BadRequest(ModelState);
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return NotFound(new { message = "User account not found" });
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (result.Succeeded)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim("roleType", user.RoleType.ToString())
                };


                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(principal);

                //var claimsIdentity = new ClaimsIdentity(claims, IdentityConstants.ApplicationScheme);
                //var principal = new ClaimsPrincipal(claimsIdentity);

                //await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, principal);


                //var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //var principal = new ClaimsPrincipal(claimsIdentity);

                //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                //await HttpContext.SignInAsync(principal);
                //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                //    new ClaimsPrincipal(claimsIdentity));

                return Ok();
            }

            return Unauthorized();
        }

        public class LoginModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
