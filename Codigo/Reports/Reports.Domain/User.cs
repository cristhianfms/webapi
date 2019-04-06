using System;

namespace Reports.Domain
{
    public enum UserType {A,M};

    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserType Rol { get; set; }
    }
}