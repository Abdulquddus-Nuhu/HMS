using System.ComponentModel.DataAnnotations;

namespace Alansar.Core.Entities
{
    /// <summary>
    /// Academic year/Session/Calendar
    /// </summary>
    public class Session : BaseEntity
    {
        [MaxLength(55)]
        public string Year { get; set; } // Format: "2023/2024"
        public DateTime? StartDate { get; set; }  
        public DateTime? EndDate { get; set; }  
    }
}
