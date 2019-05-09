using System;
using System.Collections.Generic;
using System.Linq;
using Reports.Domain;

namespace Reports.Webapi.Models
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}