using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utlity
{
    interface IResult
    {
        bool Success { get; set; }
        int AffectedRows { get; set; }
        string Message { get; set; }
        dynamic Scalar { get; set; }
    }
}
    