namespace Alansar.Services
{
    public class CookieService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetCookie(string key = "auth_token")
        {
            return _httpContextAccessor.HttpContext.Request.Cookies[key];
        }
    }

}
