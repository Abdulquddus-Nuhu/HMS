using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alansar.Core.Entities
{
    public interface ITenant
    {
        public string TenantKey { get; set; }
    }
}
