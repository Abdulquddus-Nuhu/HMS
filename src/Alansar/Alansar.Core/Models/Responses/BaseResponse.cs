using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alansar.Core.Models.Responses
{
    public record BaseResponse
    {
        public int Code { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
