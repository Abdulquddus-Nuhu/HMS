using Alansar.Entities.Identity;

namespace Alansar.Entities
{
    public class Student : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {MiddleName} {LastName}";
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public string? Password { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
