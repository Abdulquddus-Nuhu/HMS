using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alansar.Core.Models.Requests.Plan
{
    public record CreatePlanRequest
    {
        public string Amount { get; set; }
        public string Name { get; set; }
        public string Interval { get; set; }
        public string? Currency { get; set; }
        public int? Duration { get; set; }
    }
}
