using System;

namespace Reports.Domain
{
    public class Session
    {
        public Guid Token { get; set; }
        public User User { get; set; }
        public Guid Id { get; set; }

        public Session()
        {
            User = null;
            Token = Guid.Empty;
            Id = Guid.Empty;

        }
    }
}