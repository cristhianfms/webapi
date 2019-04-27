using System;

namespace Reports.Domain
{
    

    public class User
    {
        public enum UserType {A,M};
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserType Rol { get; set; }

        public bool IsValid()
        {
            return NameValidation() &&
                LastNameValidation() &&
                UserNameValidation() &&
                PasswordValidation() &&
                RolValidation() &&
                IdValidation();
        }

        private bool RolValidation()
        {
            return !String.IsNullOrEmpty(Name);
        }

        private bool PasswordValidation()
        {
            return !String.IsNullOrEmpty(LastName);
        }

        private bool UserNameValidation()
        {
            return !String.IsNullOrEmpty(UserName);
        }

        private bool LastNameValidation()
        {
            return !String.IsNullOrEmpty(Password);
        }

        private bool NameValidation()
        {
            return !String.IsNullOrEmpty(Rol.ToString());
        }

        private bool IdValidation()
        {
            return Id != Guid.Empty;
        }
    }
}