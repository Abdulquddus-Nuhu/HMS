using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

//namespace MudBlazorWebApp2.Pages.Auth
//{
//    public class ForgotPasswordModel : PageModel
//    {
//        public void OnGet()
//        {
//        }
//    }


//}

namespace Alansar.Pages.Auth
{
    public class ForgotPasswordModel : PageModel
    {
        [BindProperty]
        public ResetModel Input { get; set; }

        public bool IsLoading { get; set; } = false;

        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public ForgotPasswordModel(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            IsLoading = true;

            var response = await _httpClient.PostAsJsonAsync("api/Auth/forgot-password", Input);

            IsLoading = false;

            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Password reset link sent. Please check your email.";
                return RedirectToPage("/Login");
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to send reset link. Please try again.";
                return Page();
            }
        }

        public class ResetModel
        {
            [Required(ErrorMessage = "Email is required")]
            [EmailAddress(ErrorMessage = "Invalid email address")]
            public string Email { get; set; }
        }
    }
}
