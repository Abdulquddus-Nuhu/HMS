using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alansar.Core.Models.Responses
{
    public record PlanResponse
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public int FlutterwavePlanId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Interval { get; set; }
        public int Duration { get; set; }
        public string Token { get; set; }
        public string Currency { get; set; }
        public bool Status { get; set; }
    }
}
