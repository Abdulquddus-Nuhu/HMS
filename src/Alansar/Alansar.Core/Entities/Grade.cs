using System.ComponentModel.DataAnnotations;

namespace Alansar.Core.Entities
{
    /// <summary>
    /// CLass/Grade/Level
    /// </summary>
    public class Grade : BaseEntity
    {
        [MaxLength(55)]
        public string Name { get; set; } = string.Empty; // Example: "JSS1", "JSS2"

    }
}
