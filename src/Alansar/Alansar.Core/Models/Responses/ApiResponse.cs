using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alansar.Core.Models.Responses
{
    public record ApiResponse<TData> : BaseResponse
    {
        public TData? Data { get; set; }
    }
}
