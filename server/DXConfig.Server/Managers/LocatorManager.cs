using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Interfaces;

namespace DXConfig.Server.Managers
{
    public class LocatorManager : ILocatorManager
    {
        const string DefaultEnvironment = "dev";

        public string Find(string appid, string optEnvironment)
        {
            if (appid == null)
                throw new ArgumentNullException("appid");

            return InternalFind(null, appid, optEnvironment);
        }

        public string SecureFind(string user, string appid, string optEnvironment)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            if (appid == null)
                throw new ArgumentNullException("appid");

            return InternalFind(user, appid, optEnvironment);
        }

        string InternalFind(string optUser, string appid, string optEnvironment)
        {
            string environment = optEnvironment ?? DefaultEnvironment;

            if (!CheckUserHasPermission(optUser, appid, optEnvironment))
                return null;

            return ResolveName(appid, environment);
        }

        bool CheckUserHasPermission(string user, string appid, string environment)
        {            
            // fake test: root has full access
            if (user == "root")
                return true;

            // fake test: if not root, then production access is denied
            if (environment == "prod")
                return false;

            // fake test: all access for the other environments
            return true;
        }

        string ResolveName(string appid, string environment)
        {
            return $"{appid}/{environment}";
        }
    }
}
