using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utlity
{
    public interface ILogging
    {
        void WriteLog(string message);
        void WriteErrorLog(string message);

    }
}
