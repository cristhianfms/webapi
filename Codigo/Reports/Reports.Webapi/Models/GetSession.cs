using Reports.Domain;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Reports.Webapi.Models
{
    public class GetSession : Model<Session, GetSession>
    {
        public Guid Token { get; set; }
        public User User { get; set; }

        public GetSession()
        {

        }

        public GetSession(Session session)
        {
            SetModel(session);
        }

        public override Session ToEntity() => new Session()
        {
            Token = this.Token,
            User = this.User,
        };

        protected override GetSession SetModel(Session session)
        {
            Token = session.Token;
            User = session.User;

            return this;
        }
    }
}