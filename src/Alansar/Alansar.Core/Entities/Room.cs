
namespace Alansar.Core.Entities
{
    public class Room : BaseEntity
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public string? Type { get; set; }
        public bool IsAvailable { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public string? SessionYear { get; set; }  // New Field
        public List<Student> Students { get; set; } = new List<Student>();  // Relationship to Students

        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
