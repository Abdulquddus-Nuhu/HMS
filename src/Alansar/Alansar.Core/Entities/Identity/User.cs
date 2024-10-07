using Alansar.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alansar.Core.Entities.Identity
{
    public class User : IdentityUser<Guid>, ITenant
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {MiddleName} {LastName}";
        public RoleType RoleType { get; set; }

        public bool IsDeleted { get; set; }
        public string? DeletedBy { get; set; } = string.Empty;
        public virtual DateTime? Deleted { get; set; }
        public string? CreatedBy { get; set; } = string.Empty;
        public virtual DateTime Created { get; set; }
        public virtual DateTime? Modified { get; set; }
        public virtual string? LastModifiedBy { get; set; }
        public bool IsActive { get; set; }
        public string TenantKey { get; set; }

        //protected User() -- inherited cannot use constructor
        public User()
        {
            Id = Guid.NewGuid();
            IsDeleted = false;
            Created = DateTime.UtcNow;
        }
    }
}
