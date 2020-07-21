using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoices.Logger.Models.Output
{
    public class LogOutput
    {
        public string User { get; set; }

        public string IpAddress { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public string Arguments { get; set; }

        public string ExceptionMessage { get; set; }

        public string ExceptionType { get; set; }

        public string StackTrace { get; set; }

        public DateTime Date { get; set; }
    }
}
