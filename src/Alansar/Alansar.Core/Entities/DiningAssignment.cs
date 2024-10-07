using System.ComponentModel.DataAnnotations;

namespace Alansar.Core.Entities
{
    public class DiningAssignment : BaseEntity
    {
        public Guid StudentId { get; set; }
        public Guid DiningSpaceId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Student Student { get; set; }
        public DiningSpace DiningSpace { get; set; }
    }

}
