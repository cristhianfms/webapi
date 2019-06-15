using System;

namespace Reports.Logger.Domain
{
    public class Log
    {
        public Guid Id { get; set; }
        public String UserName { get; set; }
        public DateTime Date { get; set; }
        public String Action { get; set; }
    }
}