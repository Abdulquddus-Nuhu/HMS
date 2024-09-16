using Alansar.Entities.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Alansar.Pages.Auth
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LogoutModel(SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    // Log the user out
        //    await _signInManager.SignOutAsync();

        //    // Redirect to the login page or homepage
        //    return LocalRedirect("/login");
        //}
        public async Task<IActionResult> OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                // Log the user out
                await _signInManager.SignOutAsync();
            }

            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await _signInManager.SignOutAsync();
            return LocalRedirect("/login");
        }
        //public void OnGet()
        //{
        //}
    }
}
