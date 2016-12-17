using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Web;

namespace CDP.WebApp
{
    public static class Security
    {
        public static void Config()
        {
            string usercredentials = ConfigurationManager.AppSettings["WSUserName"];
            string passcredentials = ConfigurationManager.AppSettings["WSPassword"];
            string domaincredentials = ConfigurationManager.AppSettings["WSDomain"];

            WSFrameworkSeguridad.SecurityProvider securityProvider = new WSFrameworkSeguridad.SecurityProvider();

            securityProvider.Credentials = new System.Net.NetworkCredential(usercredentials, passcredentials, domaincredentials);
            securityProvider.Url = ConfigurationManager.AppSettings["URLWSSeguridad"];

            var Permiso = securityProvider.UserLogonByName("IRSACORP\\Sposzalski", 29);
            var oGrupos = securityProvider.GroupsListPerUser(Permiso, 29);
            foreach (var Grupo in oGrupos)
            {
                foreach (var Rol in securityProvider.PermissionListPerGroup(Grupo))
                {
                    HttpContext.Current.Session.Add(Rol.Description, Rol.Id.ToString());
                }
            }
        }

        public static bool IsUserInRole(string RoleName)
        {
            foreach (var item in HttpContext.Current.Session.Keys)
            {
                if (item.ToString() == RoleName)
                    return true;
            }

            return false;
        }
    }
}