//using Alansar.Data;

using Alansar.Core.Entities.Identity;

namespace Alansar.Core.Entities
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {MiddleName} {LastName}";
        public string Email { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public int UserId { get; set; }
        //public Guid UserId { get; set; }
        //public User? User { get; set; }
        public string? Password { get; set; }
        public ICollection<Booking>? Bookings { get; set; }

        public int? GradeId { get; set; }
        //public Guid? GradeId { get; set; }
        public Grade? Grade { get; set; }
    }
}
