using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDP.Repositories
{
    public static class SessionWrapper
    {
        public static string GetUser()
        {
            if (System.Web.HttpContext.Current.User != null)
                return System.Web.HttpContext.Current.User.Identity.Name;
            else 
                return string.Empty;
        }
    }
}