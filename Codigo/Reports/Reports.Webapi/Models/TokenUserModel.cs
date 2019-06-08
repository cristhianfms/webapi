using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reports.Webapi.Models;
using Reports.Domain;

namespace Reports.Webapi.Models
{
    public class TokenUserModel : Model<User, TokenUserModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public bool Admin { get; set; } = false;
        public string Mail { get; set; }
        public Guid? Token { get; set; }

        public TokenUserModel()
        {
        }

        public TokenUserModel(User entity)
        {
            SetModel(entity);
        }

        public override User ToEntity()
        {
            return new User() { };
        }

        protected override TokenUserModel SetModel(User entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.UserName = entity.UserName;
            this.LastName = entity.LastName;
            this.Admin = entity.Admin;
            this.Mail = entity.Mail;
            return this;
        }
    }
}
