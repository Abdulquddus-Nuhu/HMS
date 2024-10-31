using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Alansar.Core.Models.Responses
{
    public class PaymentPlanResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public PaymentPlan Data { get; set; }
    }

    public class PaymentPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Interval { get; set; }
        public int Duration { get; set; }
        public string Status { get; set; }
        public string Currency { get; set; }
        [JsonPropertyName("plan_token")]
        public string PlanToken { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
