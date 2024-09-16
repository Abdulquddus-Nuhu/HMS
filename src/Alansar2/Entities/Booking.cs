namespace Alansar.Entities
{
    public class Booking : BaseEntity
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public DateTime BookingDate { get; set; }
        public string SessionYear { get; set; }
    }
}
