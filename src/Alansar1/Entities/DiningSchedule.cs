namespace Alansar.Entities
{
    public class DiningSchedule : BaseEntity
    {
        public int Id { get; set; }
        public int DiningSpaceId { get; set; }
        public DiningSpace DiningSpace { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public DateTime ScheduledDate { get; set; }
    }
}
