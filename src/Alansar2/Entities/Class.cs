using System.ComponentModel.DataAnnotations;

namespace Alansar.Entities
{
    /// <summary>
    /// CLass/Grade/Level
    /// </summary>
    public class Class : BaseEntity
    {
        public int Id { get; set; }

        [MaxLength(55)]
        public string Name { get; set; } // Example: "JSS1", "JSS2"

    }
}
