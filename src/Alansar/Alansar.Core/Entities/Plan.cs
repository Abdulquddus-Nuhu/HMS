using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alansar.Core.Entities
{
    public class Plan
    {

        /*
         * 
         * :{,"interval":"Hourly","duration":0,"status":"active","currency":"NGN","plan_token":"rpp_a1d291c382da20e3a118","created_at":"2024-10-31T12:26:42.000Z"}}

         */
        public int FlutterwavePlanId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Interval { get; set; }
        public int Duration { get; set; }
        public string Token { get; set; }
        public string Currency { get; set; }
        public bool status { get; set; }







        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public string? DeletedBy { get; set; } = string.Empty;
        public virtual DateTime? Deleted { get; set; }
        public string? CreatedBy { get; set; } = string.Empty;
        public virtual DateTime Created { get; set; }
        public virtual DateTime? Modified { get; set; }
        public virtual string? LastModifiedBy { get; set; }
    }
}
