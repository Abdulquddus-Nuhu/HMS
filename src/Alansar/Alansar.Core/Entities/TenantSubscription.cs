using Alansar.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alansar.Core.Entities
{
    public class TenantSubscription : BaseEntity
    {
        public int TenantId { get; set; }
        public Tenant? Tenant { get; set; }

        public SubscriptionPlanType PlanType { get; set; }
        public BillingCycle BillingCycle { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool HasPaid { get; set; } = false;
        public decimal Amount { get; set; }
        public decimal FeeAmount { get; set; }
    }
}
