using JigneshPractical.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JigneshPractical.Utilis
{
    public class SessionUtils
    {
        private const string UserSessionIn = "UserSession";

        public static User_Login_Result UserSession
        {
            get
            {
                User_Login_Result userauth = (User_Login_Result)HttpContext.Current.Session[UserSessionIn];
                return userauth;
            }

            set
            {
                HttpContext.Current.Session[UserSessionIn] = value;
            }
        }
    }
}