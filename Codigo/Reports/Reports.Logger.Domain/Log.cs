using System;

namespace Reports.Logger.Domain
{
    public class Log
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
    }
}