using System;
using System.Collections.Generic;

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

        public virtual IEnumerable<AreaManager> AreaManagers { get; set; }

        public bool IsValid()
        {
            return ValidateName() &&
                ValidateLastName() &&
                ValidateUserName() &&
                ValidatePassword() &&
                ValidateID();
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