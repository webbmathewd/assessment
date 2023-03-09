using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TW.DeveloperTest.WorkLibrary
{
    internal interface ILogger
    {
        void LogMessage(SeverityType severity, string message);
    }
}
