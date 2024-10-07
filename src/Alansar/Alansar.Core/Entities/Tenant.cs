using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alansar.Core.Entities
{
    public class Tenant
    {

        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public string? DeletedBy { get; set; } = string.Empty;
        public virtual DateTime? Deleted { get; set; }
        public string? CreatedBy { get; set; } = string.Empty;
        public virtual DateTime Created { get; set; }
        public virtual DateTime? Modified { get; set; }
        public virtual string? LastModifiedBy { get; set; }
        public bool IsActive { get; set; }



        public string SchoolName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public Tenant()
        {
            Id = Guid.NewGuid();
            IsDeleted = false;
            Created = DateTime.UtcNow;
        }


    }
}
