using Alansar.Enums;
using Microsoft.AspNetCore.Identity;

namespace Alansar.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {MiddleName} {LastName}";
        public RoleType RoleType { get; set; }
    }
}
