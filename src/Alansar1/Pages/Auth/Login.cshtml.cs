using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Alansar.Services;
using Alansar.Enums;
using Alansar.Entities.Identity;
using Alansar.Data;

namespace Alansar.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _context;
        private readonly SignInManager<User> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserService _userService;

        public LoginModel(SignInManager<User> signInManager, UserManager<User> userManager,
            AppDbContext context, IHttpContextAccessor httpContextAccessor, UserService userService)
        {
            _signInManager = signInManager;
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }


        [BindProperty]
        public LoginInputModel Input { get; set; }

        public class LoginInputModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }




        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.FindByEmailAsync(Input.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User account not found.");
                return Page();
            }

            var result = await _signInManager.PasswordSignInAsync(user, Input.Password, false, false);

            if (result.Succeeded)
            {
                // Add claims to identity
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.RoleType.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(claimsIdentity);

                // Sign in the user and set the authentication cookie
                await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                // Check the role and redirect based on it
                if (user.RoleType == RoleType.Student)
                {
                    var student = _context.Students.FirstOrDefault(x => x.UserId == user.Id);
                    if (student != null)
                    {
                        //Todo: access student room and dining space
                    }
                    _userService.RoleType = user.RoleType;
                    _userService.Email = user.Email;
                    _userService.FirstName = user.FirstName;
                    _userService.MiddleName = user.MiddleName;
                    _userService.LastName = user.LastName;


                    return LocalRedirect("/student-home");
                   // return RedirectToPage("/student-home"); // Adjust the page name as per your project
                }
                else if (user.RoleType == RoleType.Admin)
                {
                    _userService.RoleType = user.RoleType;
                    _userService.Email = user.Email;
                    _userService.FirstName = user.FirstName;
                    _userService.MiddleName = user.MiddleName;
                    _userService.LastName = user.LastName;

                    return LocalRedirect("/admin-home");
                    //return RedirectToPage("/"); // Adjust the page name as per your project
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return Page();
        }

    }
}
