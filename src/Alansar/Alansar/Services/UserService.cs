using Alansar.Core.Enums;

namespace Alansar.Services
{
    public class UserService
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {MiddleName} {LastName}";
        public RoleType RoleType { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string RoomNumber { get; set; }
        public string DinigSpace { get; set; }
    }
}
