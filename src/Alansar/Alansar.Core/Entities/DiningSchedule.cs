
namespace Alansar.Core.Entities
{
    public class DiningSchedule : BaseEntity
    {
        public int DiningSpaceId { get; set; }
        //public Guid DiningSpaceId { get; set; }
        public DiningSpace DiningSpace { get; set; }
        public int StudentId { get; set; }
        //public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public DateTime ScheduledDate { get; set; }
    }
}
