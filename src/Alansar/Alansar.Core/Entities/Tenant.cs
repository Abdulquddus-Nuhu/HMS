using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alansar.Core.Entities
{
    public class Tenant : BaseEntity
    {
        public string SchoolName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
