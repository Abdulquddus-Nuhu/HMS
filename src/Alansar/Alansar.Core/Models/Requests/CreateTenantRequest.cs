using Alansar.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alansar.Core.Models.Requests
{
    public record CreateTenantRequest
    {
        public string SchoolName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public SubscriptionPlanType PlanType { get; set; }
        public BillingCycle BillingCycle { get; set; }
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
