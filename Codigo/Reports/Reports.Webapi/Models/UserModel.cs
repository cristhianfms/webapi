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
        public bool Admin { get; set; } = false;
        public string Password { get; set; }

        public UserModel() { }

        public UserModel(User entity)
        {
            SetModel(entity);
        }

        public override User ToEntity()
        {
            return new User()
            {
                Id = this.Id,
                Name = this.Name,
                LastName = this.LastName,
                UserName = this.UserName,
                Password = this.Password,
                Admin = this.Admin
                
            };
        }
    }
}