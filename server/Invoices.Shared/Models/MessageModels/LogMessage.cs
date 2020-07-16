using System;

namespace Invoices.Shared.Models.MessageModels
{
    public class LogMessage
    {
        public string User { get; set; }

        public string IpAddress { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public string Arguments { get; set; }

        public string ExceptionMessage { get; set; }

        public string ExceptionType { get; set; }

        public string StackTrace { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
