using System;
using System.Collections.Generic;
using System.Text;
using Reports.Domain;

namespace Reports.BusinessLogic
{
    public class UserValidation
    {
        public static void IsValidUser(User usr)
        {
            if (usr == null)
                throw new BusinessLogicException("No instance of user");
        }
    }
}
