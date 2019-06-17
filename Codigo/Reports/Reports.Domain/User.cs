using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace Reports.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; } = false;
        public string Mail { get; set; }

        public virtual IEnumerable<AreaUser> AreaUsers { get; set; }
        public virtual IEnumerable<IndicatorConfig> IndicatorConfigs { get; set; }
        public User Update(User usr)
        {
            if (usr.ValidateName())
            {
                this.Name = usr.Name;
            }
            if (usr.ValidateLastName())
            {
                this.LastName = usr.LastName;
            }
            if (usr.ValidateUserName())
            {
                this.UserName = usr.UserName;
            }
            if (usr.ValidatePassword())
            {
                this.Password = usr.Password;
            }
            if (usr.ValidateMail())
            {
                this.Mail = usr.Mail;
            }
            return this;
        }
        public bool IsValid()
        {
            return ValidateName() &&
                ValidateLastName() &&
                ValidateUserName() &&
                ValidatePassword() &&
                ValidateID() &&
                ValidateMail();
        }
        private bool ValidateMail()
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(this.Mail);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private bool ValidateName()
        {
            return !String.IsNullOrEmpty(Name);
        }
        private bool ValidatePassword()
        {
            return !String.IsNullOrEmpty(LastName);
        }
        private bool ValidateUserName()
        {
            return !String.IsNullOrEmpty(UserName);
        }
        private bool ValidateLastName()
        {
            return !String.IsNullOrEmpty(Password);
        }
        private bool ValidateID()
        {
            return Id != Guid.Empty;
        }
    }
}