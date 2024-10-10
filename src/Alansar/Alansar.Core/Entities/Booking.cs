
namespace Alansar.Core.Entities
{
    public class Booking : BaseEntity
    {
        public int RoomId { get; set; }
        //public Guid RoomId { get; set; }
        public Room Room { get; set; }
        public int StudentId { get; set; }
        //public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public DateTime BookingDate { get; set; }
        public string SessionYear { get; set; }
    }
}
