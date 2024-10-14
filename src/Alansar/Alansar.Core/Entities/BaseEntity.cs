using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Alansar.Core.Entities
{
    public class BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string? DeletedBy { get; set; } = string.Empty;
        public virtual DateTime? Deleted { get; set; }
        public string? CreatedBy { get; set; } = string.Empty;
        public virtual DateTime Created { get; set; }
        public virtual DateTime? Modified { get; set; }
        public virtual string? LastModifiedBy { get; set; }
        public bool IsActive { get; set; }
        public string? TenantKey { get; set; }

        protected BaseEntity()
        {
            //Id = Guid.NewGuid();
            IsDeleted = false;
            //Created = DateTime.Now;
            Created = DateTime.UtcNow;
        }
    }
}
