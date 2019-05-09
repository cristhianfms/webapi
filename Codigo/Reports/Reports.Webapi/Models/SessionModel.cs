using System;
using System.Collections.Generic;
using System.Linq;
using Reports.Domain;

namespace Reports.Webapi.Models
{
    public class SessionModel : Model<Session, SessionModel>
    {
        public Guid Token { get; set; }
        public User User { get; set; }
        public Guid Id { get; set; }

        public SessionModel() { }

        public SessionModel(Session entity)
        {
            SetModel(entity);
        }

        public override Session ToEntity()
        {
            return new Session()
            {
                Id = this.Id,
                User = this.User,
                Token = this.Token
            };
        }

        protected override SessionModel SetModel(Session entity)
        {
            Id = entity.Id;
            User = entity.User;
            Token = entity.Token;
            return this;
        }

    }
}
