using System;
using System.Collections.Generic;
using System.Linq;
using Reports.Domain;

namespace Reports.Webapi.Models
{
    public class UserModel : Model<User, UserModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public char Role { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }

        public UserModel() { }

        public UserModel(User entity)
        {
            SetModel(entity);
        }

        public override User ToEntity()
        {
            User newUser =  new User()
            {
                Id = this.Id,
                Name = this.Name,
                LastName = this.LastName,
                UserName = this.UserName,
                Password = this.Password,
                Mail = this.Mail
            };
            if (this.Role == 'M')
            {
                newUser.Admin = false;
            }
            if (this.Role == 'A')
            {
                newUser.Admin = true;
            }
            return newUser;
        }
        protected override UserModel SetModel(User entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            LastName = entity.LastName;
            UserName = entity.UserName;
            Role = entity.Admin ? 'A' : 'M';
            Password = entity.Password;
            Mail = entity.Mail;
            return this;
        }
    }
}